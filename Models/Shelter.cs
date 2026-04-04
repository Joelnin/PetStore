using System.ComponentModel.DataAnnotations;
// using CountryData.Standard;

namespace PetStore
{
  public class Shelter
  {
    public string? Id { get; set; }

    [Required(ErrorMessage = "The Shelter Name is required.")]
    [MaxLength(150, ErrorMessage = "The Name is too long (maximum 150 letters).")]
    [Display(Name = "Shelter Name")]
    public required string Name { get; set; }
    
    [Required(ErrorMessage = "Please select a country.")]
    [StringLength(2, MinimumLength = 2)]
    public required string Country { get; set; } // Code will be ISO (e.g "VE") si It just need 2

    [Required(ErrorMessage = "Please select a state or region.")] // This needs more letters for the whole name
    public required string State { get; set; }

    public string? City { get; set; } // This is not mandatory, it an be null

    public string? Email { get; set; } // This is not mandatory, it an be null. This is for contact info, just public info.

    public string? Phone { get; set; } // This is not mandatory, it an be null. This is for contact info, just public 

    public required string User_id { get; set; } // Foreign Key for the owner of the shelter
  }

}

