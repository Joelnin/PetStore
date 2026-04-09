using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;

namespace PetStore.Models
{
  // Represents the user application form for adopting, fostering, sponsoring, or volunteering.
  public class ApplicationForm
  {
    // Primary key for database
    [Parameter]
    public int Id { get; set; }
    
    public string PetName { get; set; }
    public string ShelterName { get; set; }

    // Personal information
    [Required(ErrorMessage = "Please fill in your full name")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters")]
    public string? FullName { get; set; }

    [Required(ErrorMessage = "Please fill in your email")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Please fill in your phone number")]
    [RegularExpression(@"^\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$",
      ErrorMessage = "Enter a valid phone number")]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "Please fill in your address")]
    public string? Address { get; set; }

    // Selected application type
    [Required(ErrorMessage = "Please select one")]
    public string? HelpType { get; set; }

    // Conditional fields shown depending on help type
    public string? HousingStatus { get; set; }
    public string? OtherPets { get; set; }
    public string? FosterLength { get; set; }
    public string? Experience { get; set; }
    public string? Reason { get; set; }
    public int? MonthlyAmount { get; set; }

    // Date submitted
    public DateTime SubmittedAt { get; set; } = DateTime.Now;

    // Requires user confirmation before submission
    [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree before submitting.")]
    public bool AgreeToTerms { get; set; }
  }
}