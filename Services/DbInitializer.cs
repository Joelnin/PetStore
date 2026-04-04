using Microsoft.AspNetCore.Identity;
using PetStore.Models;

namespace PetStore.Services;

public static class DbInitializer
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        Console.WriteLine("=== DbInitializer started ===");

        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        // Crear Roles (Admin y User)
        string[] roleNames = { Roles.Admin, Roles.Client };

        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                Console.WriteLine($"Role '{roleName}' created: {result.Succeeded}");
            }
            else
            {
                Console.WriteLine($"Role '{roleName}' already exists.");
            }
        }

        Console.WriteLine("=== DbInitializer finished ===\n");
        Console.WriteLine("Roles creados correctamente. Puedes registrar tu primer usuario manualmente.");
    }
}