using PetStore.Data;
using PetStore.Models;
using Microsoft.EntityFrameworkCore;

namespace PetStore.Services;

// This service handles pet, category, and shelter data operations. It acts as the main connection between the UI and the database context.
public class PetService
{
  private readonly PetStoreContext _context;

  // Inject the database context so this service can read and update data.
  public PetService(PetStoreContext context)
  {
    _context = context;
  }

  // Return all pets stored in the database.
  public List<Pet> GetAllPets()
  {
    return _context.Pets.ToList();
  }

  // Return pets that match a selected category. If no category is provided, return an empty list.
  public List<Pet> GetPetsByCategory(string? category)
  {
    if (string.IsNullOrWhiteSpace(category))
    {
      return new List<Pet>();
    }

    // Compare categories in lowercase so filtering is case-insensitive.
    return _context.Pets
      .Where(p => p.Type.ToLower() == category.ToLower())
      .ToList();
  }

  // Find one pet by its unique id. Returns null if no matching pet is found.
  public Pet? GetPetById(string id)
  {
    return _context.Pets.FirstOrDefault(p => p.Id == id);
  }

  // Add a new pet to the database. The pet type is cleaned first to keep category names consistent.
  public void AddPet(Pet pet)
  {
    if (string.IsNullOrWhiteSpace(pet.Id))
    {
      pet.Id = Guid.NewGuid().ToString();
    }

    pet.Type = pet.Type.Trim().ToLower();

    _context.Pets.Add(pet);
    _context.SaveChanges();
  }

  // Update an existing pet's information. Only save changes if the pet already exists in the database.
  public void UpdatePet(Pet updatedPet)
  {
    var pet = _context.Pets.FirstOrDefault(p => p.Id == updatedPet.Id);

    if (pet != null)
    {
      pet.Name = updatedPet.Name;
      pet.Type = updatedPet.Type.Trim().ToLower();
      pet.Breed = updatedPet.Breed;
      pet.YearOfBirth = updatedPet.YearOfBirth;
      pet.Description = updatedPet.Description;
      pet.ImageUrl = updatedPet.ImageUrl;

      _context.SaveChanges();
    }
  }

  // Delete a pet by id if it exists.
  public void DeletePet(string id)
  {
    var pet = _context.Pets.FirstOrDefault(p => p.Id == id);

    if (pet != null)
    {
      _context.Pets.Remove(pet);
      _context.SaveChanges();
    }
  }

  // Return all pet categories from the database.
  public List<PetCategory> GetAllCategories()
  {
    return _context.PetCategories.ToList();
  }

  // Add a new category if it does not already exist.  The category name is normalized to prevent duplicates with different casing.
  public void AddCategory(PetCategory category)
  {
    category.Name = category.Name.Trim().ToLower();

    bool exists = _context.PetCategories.Any(c => c.Name == category.Name);

    if (!exists)
    {
      _context.PetCategories.Add(category);
      _context.SaveChanges();
    }
  }

  // Delete a category only if it exists and is not currently being used by any pets. Returns true if deleted successfully, otherwise false.
  public bool DeleteCategory(int id)
  {
    var category = _context.PetCategories.FirstOrDefault(c => c.Id == id);

    if (category == null)
    {
      return false;
    }

    // Prevent deleting categories that are still assigned to pets.
    bool categoryInUse = _context.Pets.Any(p => p.Type.ToLower() == category.Name.ToLower());

    if (categoryInUse)
    {
      return false;
    }

    _context.PetCategories.Remove(category);
    _context.SaveChanges();

    return true;
  }

  // Update a category name and also update all pets using the old category name. This keeps pet records consistent after a category rename.
  public void UpdateCategory(PetCategory updatedCategory)
  {
    var category = _context.PetCategories.FirstOrDefault(c => c.Id == updatedCategory.Id);

    if (category != null)
    {
      string oldName = category.Name;
      string newName = updatedCategory.Name.Trim().ToLower();

      category.Name = newName;

      // Update all pets that were assigned to the old category name.
      var petsToUpdate = _context.Pets
          .Where(p => p.Type.ToLower() == oldName.ToLower())
          .ToList();

      foreach (var pet in petsToUpdate)
      {
        pet.Type = newName;
      }

      _context.SaveChanges();
    }
  }

  // Return all shelters in the database.
  public List<Shelter> GetAllShelters()
  {
    return _context.Shelters.ToList();
  }

  // Return shelters filtered by country. If no country is provided, return an empty list.
  public List<Shelter> GetSheltersByCountry(string? country)
  {
    if (string.IsNullOrWhiteSpace(country))
    {
      return new List<Shelter>();
    }

    // Compare country names in lowercase so filtering is case-insensitive.
    return _context.Shelters
      .Where(s => s.Country.ToLower() == country.ToLower())
      .ToList();
  }

  // Find one shelter by its unique id. Returns null if no matching shelter is found.
  public Shelter? GetShelterById(string id)
  {
    return _context.Shelters.FirstOrDefault(s => s.Id == id);
  }

  public string GetShelterNameById(string shelterId)
  {
    return _context.Shelters
        .FirstOrDefault(s => s.Id == shelterId)?.Name ?? "Unknown Shelter";
  }

  // Return dashboard totals for pets and shelters. Async is used here because database counting operations can be awaited efficiently.
  public async Task<(int pets, int shelters)> GetGlobalTotalsAsync()
  {
    var petsCount = await _context.Pets.CountAsync();
    var sheltersCount = await _context.Shelters.CountAsync();

    return (petsCount, sheltersCount);
  }
}