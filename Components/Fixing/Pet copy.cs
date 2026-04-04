using System.ComponentModel.DataAnnotations;

namespace PetStore.Models;

public class Petties
{
  public int Id { get; set; }
  [Required(ErrorMessage = "*Pet name is required")]
  public string Name { get; set; } = "";
  [Required(ErrorMessage = "*Pet must have a category")]
  public string Category { get; set; } = "";
  [Required(ErrorMessage = "*Pet breed is required")]
  public string Breed { get; set; } = "";
  [Range(0,1000, ErrorMessage = "*Age must be between 0 and 1000")]
  public int Age { get; set; }
  public string Description { get; set; } = "";
  public string ImageUrl { get; set; } = "";
}