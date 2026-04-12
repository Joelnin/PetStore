using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStore.Models
{
    [Table("Donations")] // Forzamos el nombre físico en la DB
    public class Donation
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)] // Universal: nvarchar(100) en SQL / TEXT en SQLite
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Range(1, 10000, ErrorMessage = "Donation must be between $1 and $10,000")]
        public int Amount { get; set; }

        public bool IsAnonymous { get; set; } = false;

        [Required]
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DonationStatus Status { get; set; } = DonationStatus.Pending;

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}