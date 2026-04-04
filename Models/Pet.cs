using System.ComponentModel.DataAnnotations;

namespace PetStore
{

  public class Pet
  {
    public string? Id { get; set; }

    [Required(ErrorMessage = "Please, write a valid Name")]
    [MinLength(2, ErrorMessage = "The Name is too short (minimum 2 letters).")]
    [MaxLength(100, ErrorMessage = "The Name is too long (maximum 100 letters).")]
    [Display(Name = "Name")]
    public string Name { get; set; } = string.Empty; 
    
    [Required(ErrorMessage = "Please use a valid Type: specify whether Cat, Dog, or other.")]
    [MinLength(2, ErrorMessage = "The Type is too short (minimum 2 letters).")]
    [MaxLength(100, ErrorMessage = "The Type is too long (maximum 100 letters).")]
    [Display(Name = "Animal Type")]
    public string Type { get; set; } = string.Empty; 

    [Required(ErrorMessage = "Please, write a valid Name")]
    [MinLength(3, ErrorMessage = "The Breed is too short (minimum 3 letters).")]
    [MaxLength(100, ErrorMessage = "The Breed is too long (maximum 100 letters).")]
    [Display(Name = "Breed or Subtype")]
    public string Breed { get; set; } = string.Empty; 
    
    [Required(ErrorMessage ="Please set a valid year of birth (e.g. 2021)")]
    [Range(2010,2026, ErrorMessage = "Age must be between 0 and 16 years")]
    [Display(Name = "Year of Birth")]
    public int YearOfBirth { get; set; } // Birthday easier to sepparate from puppies (less than 2 years) and not-puppies
    
    [Required]
    [MaxLength(100, ErrorMessage = "Please use a description less than 100 letters.")]
    public string Description { get; set; } = "Beautiful soul";
    

    public string ImageUrl { get; set; } = ""; // to set later

    [Required(ErrorMessage = "Please indicate how active the animal is")]
    [Range(1, 5, ErrorMessage = "Energy level must be between 1 and 5.")]
    public int Energy { get; set; }

    [Required(ErrorMessage = "Please indicate if it is friendly")]
    public bool Is_Friendly { get; set; }

    [Required(ErrorMessage = "Please indicate if it is available for adoption")]
    public bool Is_Adopt { get; set; }

    [Required(ErrorMessage = "Please indicate if it is available for fostering for a short time")]
    public bool Is_Foster { get; set; }

    public string Shelter_id { get; set; } = string.Empty;  // This should be set with its creation

  }
}