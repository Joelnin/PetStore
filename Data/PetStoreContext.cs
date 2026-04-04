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

  public DbSet<Shelter> Shelters { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Pet>().HasData(
      new Pet
      {
          Id = "1",
          Name = "Max",
          Type = "dogs",
          Breed = "Golden Retriever",
          YearOfBirth = 2021,
          Description = "Friendly, loyal, and ready for a home.",
          ImageUrl = "https://raw.githubusercontent.com/vsyang/pet-images/main/goldenr.jpg",
          Energy = 4,
          Is_Friendly = true,
          Is_Adopt = true,
          Is_Foster = true,
          Shelter_id = "SHELTER-01"
      },
      new Pet
      {
          Id = "2",
          Name = "Luna",
          Type = "cats",
          Breed = "Siamese",
          YearOfBirth = 2022,
          Description = "Curious, calm, and full of personality.",
          ImageUrl = "https://raw.githubusercontent.com/vsyang/pet-images/main/siamese.jpg",
          Energy = 3,
          Is_Friendly = true,
          Is_Adopt = true,
          Is_Foster = false,
          Shelter_id = "SHELTER-01"
      },
      new Pet
      {
          Id = "3",
          Name = "Toothless",
          Type = "dragons",
          Breed = "Mini Flame",
          YearOfBirth = 2010, // Ajustado al rango permitido (2010-2026)
          Description = "Magical companion with fiery charm.",
          ImageUrl = "https://raw.githubusercontent.com/vsyang/pet-images/main/toothless.jpg",
          Energy = 5,
          Is_Friendly = true,
          Is_Adopt = false,
          Is_Foster = true,
          Shelter_id = "SHELTER-02"
      },
      new Pet
      {
          Id = "4",
          Name = "Sparkle",
          Type = "unicorns",
          Breed = "Silver Mane",
          YearOfBirth = 2019,
          Description = "Rare, graceful, and full of wonder.",
          ImageUrl = "https://raw.githubusercontent.com/vsyang/pet-images/main/unicorn.jpg",
          Energy = 2,
          Is_Friendly = true,
          Is_Adopt = true,
          Is_Foster = true,
          Shelter_id = "SHELTER-02"
      },
      new Pet
      {
          Id = "5",
          Name = "Cloud",
          Type = "dogs",
          Breed = "Maltese",
          YearOfBirth = 2023,
          Description = "Intelligent and handsome. He just loves to be with you.",
          ImageUrl = "https://raw.githubusercontent.com/vsyang/pet-images/main/maltese.jpg",
          Energy = 3,
          Is_Friendly = true,
          Is_Adopt = true,
          Is_Foster = true,
          Shelter_id = "SHELTER-01"
      },
      new Pet
      {
          Id = "6",
          Name = "Jimbo",
          Type = "elephants",
          Breed = "Asian Elephant",
          YearOfBirth = 2020,
          Description = "Curious, adorable, and intelligent.",
          ImageUrl = "https://raw.githubusercontent.com/vsyang/pet-images/main/elephant.jpg",
          Energy = 2,
          Is_Friendly = true,
          Is_Adopt = false,
          Is_Foster = false,
          Shelter_id = "SHELTER-03"
      },
      new Pet
      {
          Id = "7",
          Name = "Raja",
          Type = "cats",
          Breed = "Siberian Tiger",
          YearOfBirth = 2017,
          Description = "Majestic, regal, and content. All she wants is to bathe.",
          ImageUrl = "https://raw.githubusercontent.com/vsyang/pet-images/main/tiger.jpg",
          Energy = 1,
          Is_Friendly = false,
          Is_Adopt = false,
          Is_Foster = false,
          Shelter_id = "SHELTER-03"
      },
      new Pet
      {
          Id = "8",
          Name = "Marshmallow",
          Type = "birds",
          Breed = "White Cockatoo",
          YearOfBirth = 2014,
          Description = "Loves to talk, sing, and dance.",
          ImageUrl = "https://raw.githubusercontent.com/vsyang/pet-images/main/white-parrot.jpg",
          Energy = 5,
          Is_Friendly = true,
          Is_Adopt = true,
          Is_Foster = true,
          Shelter_id = "SHELTER-01"
      }
    );

    modelBuilder.Entity<PetCategory>().HasData(
        new PetCategory
        {
          Id = 1,
          Name = "dogs"
        },
        new PetCategory
        {
          Id = 2,
          Name = "cats"
        },
        new PetCategory
        {
          Id = 3,
          Name = "dragons"
        },
        new PetCategory
        {
          Id = 4,
          Name = "unicorns"
        },
        new PetCategory
        {
          Id = 5,
          Name = "birds"
        },
        new PetCategory
        {
          Id = 6,
          Name = "elephants"
        }
    );

    modelBuilder.Entity<Shelter>().HasData(
new Shelter
    {
        Id = "SHELTER-01",
        Name = "Golden Paws Rescue",
        Country = "US",
        State = "Pennsylvania",
        Email = "contact@goldenpawsrescue.org",
        User_id = "user_01"
    },
    new Shelter
    {
        Id = "SHELTER-02",
        Name = "Whisker Haven",
        Country = "CA",
        State = "Ontario",
        Email = "hello@whiskerhaven.org",
        User_id = "user_02"
    },
    new Shelter
    {
        Id = "SHELTER-03",
        Name = "Safe Wings Sanctuary",
        Country = "AU",
        State = "New South Wales",
        Email = "info@safewingssanctuary.org",
        User_id = "user_03"
    },
    new Shelter
    {
        Id = "SHELTER-04",
        Name = "Cloud in the Sky",
        Country = "VE",
        State = "Mérida",
        Email = "support@cloudinthesky.org",
        User_id = "user_04"
    },
    new Shelter
    {
        Id = "SHELTER-05",
        Name = "Wild Heart Refuge",
        Country = "ZA",
        State = "Western Cape",
        Email = "team@wildheartrefuge.org",
        User_id = "user_05"
    },
    new Shelter
    {
        Id = "SHELTER-06",
        Name = "Hope Tails Shelter",
        Country = "MX",
        State = "Guanajuato",
        Email = "care@hopetailsshelter.org",
        User_id = "user_06"
    }
    );
  }
}