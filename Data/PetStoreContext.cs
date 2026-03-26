using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetStore.Models;

namespace PetStore.Data;

public class PetStoreContext : IdentityDbContext<ApplicationUser>
{
  public PetStoreContext(DbContextOptions<PetStoreContext> options)
      : base(options)
  {
  }

  public DbSet<Pet> Pets { get; set; }

  public DbSet<PetCategory> PetCategories { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.Entity<Pet>().HasData(
        new Pet
        {
          Id = 1,
          Name = "Max",
          Category = "dogs",
          Breed = "Golden Retriever",
          Age = 3,
          Description = "Friendly, loyal, and ready for a home.",
          ImageUrl = "https://raw.githubusercontent.com/vsyang/pet-images/main/goldenr.jpg"
        },
        new Pet
        {
          Id = 2,
          Name = "Luna",
          Category = "cats",
          Breed = "Siamese",
          Age = 2,
          Description = "Curious, calm, and full of personality.",
          ImageUrl = "https://raw.githubusercontent.com/vsyang/pet-images/main/siamese.jpg"
        },
        new Pet
        {
          Id = 3,
          Name = "Toothless",
          Category = "dragons",
          Breed = "Mini Flame",
          Age = 100,
          Description = "Magical companion with fiery charm.",
          ImageUrl = "https://raw.githubusercontent.com/vsyang/pet-images/main/toothless.jpg"
        },
        new Pet
        {
          Id = 4,
          Name = "Sparkle",
          Category = "unicorns",
          Breed = "Silver Mane",
          Age = 5,
          Description = "Rare, graceful, and full of wonder.",
          ImageUrl = "https://raw.githubusercontent.com/vsyang/pet-images/main/unicorn.jpg"
        }
    );
  }

}