using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Models;

public class ApplicationUser : IdentityUser
{
    [Required]
    [MaxLength(50)]
    [Display(Name = "Name")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; } = string.Empty;
    
    [MaxLength(20)]
    [Display(Name = "Nick name")]
    public string? NickName { get; set; } = string.Empty;

    [MaxLength(100)]
    [Display(Name = "Address")]
    public string? Address { get; set; } = string.Empty;

    [Display(Name = "Date of Birth")]
    public DateTime? DateOfBirth { get; set; }

    public string DisplayNam => !string.IsNullOrEmpty(NickName) ? NickName : $"{FirstName} {LastName}";
}