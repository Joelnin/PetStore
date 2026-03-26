using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//Namespaces
using PetStore.Components;
using PetStore.Data;
using PetStore.Services;
using PetStore.Models;
var builder = WebApplication.CreateBuilder(args);

// ====================== Services ======================
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Data Source=petstore.db"; // Fallback for appsettings;

builder.Services.AddDbContext<PetStoreContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddScoped<PetService>();
// ====================== ASP.NET Core Identity ======================

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<PetStoreContext>()
.AddDefaultTokenProviders();

// ====================== Authentication (Google/MS) ======================

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddGoogle(googleOptions =>
    {
        googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
        googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
    })
    .AddMicrosoftAccount(msOptions =>
    {
        msOptions.ClientId = builder.Configuration["Authentication:Microsoft:ClientId"]!;
        msOptions.ClientSecret = builder.Configuration["Authentication:Microsoft:ClientSecret"]!;
    });

// ====================== UI & Blazor ======================

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// ====================== Middleware Pipeline ======================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

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

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PetStoreContext>();
    db.Database.EnsureCreated();
}

app.Run();