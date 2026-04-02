using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetStore.Components;
using PetStore.Data;
using PetStore.Services;
using PetStore.Models;

var builder = WebApplication.CreateBuilder(args);

// ====================== Services ======================
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PetStoreContext>(options =>
    options.UseSqlite(connectionString));

// Identity
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

// Blazor y servicios
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAntiforgery(); // Necesario para el token

// ✅ Servicios personalizados (solo una vez)
builder.Services.AddScoped<PetService>();

// Configuración de componentes interactivos (para .NET 8/9/10)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();

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
app.UseAntiforgery(); // Habilitar antiforgery

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

// Mapeo de Blazor
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


// Migraciones automáticas (opcional)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PetStoreContext>();
    db.Database.Migrate();
}

app.Run();