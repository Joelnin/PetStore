// This file configures the entire application including services, authentication, middleware pipeline, and custom routes.

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpOverrides;
using PetStore.Components;
using PetStore.Data;
using PetStore.Services;
using PetStore.Models;
using System.Security.Claims;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

// ====================== Services ======================

if (!builder.Environment.IsDevelopment())
{
    var keyVaultUri = builder.Configuration["KEYVAULT_URI"];

    if (!string.IsNullOrWhiteSpace(keyVaultUri))
    {
        builder.Configuration.AddAzureKeyVault(
            new Uri(keyVaultUri),
            new DefaultAzureCredential());
    }
}

// ====================== Database Configuration - FIX ======================
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}


if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<PetStoreContext>(options =>
        options.UseSqlite(connectionString));
}
else
{
    builder.Services.AddDbContext<PetStoreContext>(options =>
        options.UseSqlServer(connectionString, sqlOptions =>
        {
            sqlOptions.CommandTimeout(60);
            sqlOptions.EnableRetryOnFailure(5);
        }));
}

// Configure Identity system for authentication and user management
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
  options.Password.RequireDigit = true;
  options.Password.RequireLowercase = true;
  options.Password.RequireUppercase = true;
  options.Password.RequireNonAlphanumeric = false;
  options.Password.RequiredLength = 6;

  options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<PetStoreContext>()
.AddDefaultTokenProviders();

// ====================== Authentication ======================

// Siempre inicializamos Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ExternalScheme;
});

// Obtener credenciales desde configuración (appsettings o ENV)
var googleClientId = builder.Configuration["Authentication:Google:ClientId"];
var googleClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];

if (!string.IsNullOrWhiteSpace(googleClientId) &&
    !string.IsNullOrWhiteSpace(googleClientSecret))
{
    builder.Services.AddAuthentication().AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
    {
        options.ClientId = googleClientId;
        options.ClientSecret = googleClientSecret;
        options.ClaimActions.MapJsonKey(ClaimTypes.GivenName, "given_name");
    });
}
else
{
}

// Enable Blazor components with server-side interactivity
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register application services
builder.Services.AddScoped<PetService>();

// Enable cascading authentication state for components
builder.Services.AddCascadingAuthenticationState();

var app = builder.Build();

// ====================== Middleware Pipeline ======================

if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
  app.UseHsts();
}

// Overwrite HTTP to HTTPS
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
  ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// ====================== Google Login Routes ======================

// Route to initiate Google login
app.MapGet("/login-google", (IConfiguration config) =>
{
  var clientId = config["Authentication:Google:ClientId"];

  if (string.IsNullOrWhiteSpace(clientId))
  {
    return Results.BadRequest("Google authentication is not configured.");
  }

  return Results.Challenge(
      new AuthenticationProperties { RedirectUri = "/signin-google-callback" },
      new[] { GoogleDefaults.AuthenticationScheme }
  );
});


// Callback route after Google authentication completes
app.MapGet("/signin-google-callback", async (
    HttpContext context,
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager,
    IConfiguration config) =>
{
  var result = await context.AuthenticateAsync(IdentityConstants.ExternalScheme);

  if (!result.Succeeded || result.Principal == null)
  {
    return Results.Redirect("/signin");
  }

  var email = result.Principal.FindFirstValue(ClaimTypes.Email);
  var fullName = result.Principal.FindFirstValue(ClaimTypes.Name);
  var firstName = result.Principal.FindFirstValue(ClaimTypes.GivenName);

  if (string.IsNullOrWhiteSpace(email))
  {
    return Results.Redirect("/signin");
  }

  var user = await userManager.FindByEmailAsync(email);

  if (user == null)
  {
    user = new ApplicationUser
    {
      UserName = email,
      Email = email
    };

    var createResult = await userManager.CreateAsync(user);

    if (!createResult.Succeeded)
    {
      return Results.Redirect("/signin");
    }
  }

  // ====================== Claim Management ======================

  if (!string.IsNullOrWhiteSpace(firstName))
  {
    var existingClaims = await userManager.GetClaimsAsync(user);
    var existingFirstNameClaim = existingClaims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName);

    if (existingFirstNameClaim == null)
    {
      await userManager.AddClaimAsync(user, new Claim(ClaimTypes.GivenName, firstName));
    }
    else if (existingFirstNameClaim.Value != firstName)
    {
      await userManager.ReplaceClaimAsync(
        user,
        existingFirstNameClaim,
        new Claim(ClaimTypes.GivenName, firstName));
    }
  }

  if (!string.IsNullOrWhiteSpace(fullName))
  {
    var existingClaims = await userManager.GetClaimsAsync(user);
    var existingNameClaim = existingClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

    if (existingNameClaim == null)
    {
      await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Name, fullName));
    }
    else if (existingNameClaim.Value != fullName)
    {
      await userManager.ReplaceClaimAsync(
        user,
        existingNameClaim,
        new Claim(ClaimTypes.Name, fullName));
    }
  }

  // ====================== Role Assignment ======================

  var adminEmail = config["AdminSettings:SeedAdminEmail"];

  if (!string.IsNullOrWhiteSpace(adminEmail) &&
      email.Equals(adminEmail, StringComparison.OrdinalIgnoreCase))
  {
    if (!await userManager.IsInRoleAsync(user, Roles.Admin))
    {
      await userManager.AddToRoleAsync(user, Roles.Admin);
    }
  }
  else
  {
    if (!await userManager.IsInRoleAsync(user, Roles.Client))
    {
      await userManager.AddToRoleAsync(user, Roles.Client);
    }
  }

  await signInManager.SignInAsync(user, isPersistent: false);

  await context.SignOutAsync(IdentityConstants.ExternalScheme);

  return Results.Redirect("/");
});

// Logout route
app.MapGet("/logout", async (SignInManager<ApplicationUser> signInManager) =>
{
  await signInManager.SignOutAsync();
  return Results.Redirect("/");
});

// ====================== Database Seeding ======================

using (var scope = app.Services.CreateScope())
{
  var db = scope.ServiceProvider.GetRequiredService<PetStoreContext>();
  db.Database.Migrate();

  await IdentitySeeder.SeedRolesAsync(scope.ServiceProvider);
}

app.Run();
