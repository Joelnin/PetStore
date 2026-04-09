using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class Volunteer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(100)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(100)]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(100)]
        public string? Country { get; set; }

        [Required(ErrorMessage = "Country code is required")]
        [StringLength(10)]
        public string? CountryCode { get; set; }

        [Required(ErrorMessage = "Contact number is required")]
        [RegularExpression(@"^\d{7,15}$", ErrorMessage = "Please enter a valid phone number")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [StringLength(256)]
        public string? Email { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}
