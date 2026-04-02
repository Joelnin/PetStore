using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Models;

public class User : IdentityUser
{
    // Propiedades adicionales (no duplicar UserName, Email, etc.)
    [MaxLength(50)]
    [Display(Name = "Nombre")]
    public string? FirstName { get; set; }

    [MaxLength(50)]
    [Display(Name = "Apellido")]
    public string? LastName { get; set; }

    [MaxLength(30)]
    [Display(Name = "Apodo")]
    public string? NickName { get; set; }

    [MaxLength(2)]
    public string? Country { get; set; }

    [MaxLength(100)]
    public string? State { get; set; }

    [MaxLength(300)]
    public string? City { get; set; }

    [MaxLength(300)]
    public string? Address { get; set; }

    [Display(Name = "Fecha de Nacimiento")]
    public DateTime? BirthDate { get; set; }

    [MaxLength(45)]
    public string? Phone { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}