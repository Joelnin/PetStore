using System.ComponentModel.DataAnnotations;

namespace PetStore
{
  // Represents pet category; used to organize the pets
  public class PetCategory
  {
    [Key]
    public int Id { get; set; }

    // Name of category is required for validation
    [Required(ErrorMessage = "*Category name is required")]
    public string Name { get; set; } = "";
  }
}