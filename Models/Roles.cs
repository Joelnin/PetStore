namespace PetStore.Models;

// Defines application roles used for authorization
public static class Roles
{
    // Role with full access to management features
    public const string Admin = "Admin";

    // User role that signs in with limited access
    public const string Client = "Client";
}