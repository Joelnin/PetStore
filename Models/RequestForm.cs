using System.ComponentModel.DataAnnotations;

namespace PetStore.Models;

public class RequestFormModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Selecciona el tipo de solicitud.")]
    [Display(Name = "Tipo de solicitud")]
    public string RequestType { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ingresa tu nombre.")]
    [MaxLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
    [Display(Name = "Nombre")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ingresa tu apellido.")]
    [MaxLength(50, ErrorMessage = "El apellido no puede superar los 50 caracteres.")]
    [Display(Name = "Apellido")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ingresa tu correo electrónico.")]
    [EmailAddress(ErrorMessage = "Ingresa un correo válido.")]
    [Display(Name = "Correo electrónico")]
    public string Email { get; set; } = string.Empty;

    [MaxLength(100, ErrorMessage = "La dirección no puede superar los 100 caracteres.")]
    [Display(Name = "Dirección")]
    public string? Address { get; set; }

    [Display(Name = "Fecha de nacimiento")]
    public DateTime? DateOfBirth { get; set; }

    [Display(Name = "Mascota preferida")]
    public string? PreferredPetType { get; set; }
}
