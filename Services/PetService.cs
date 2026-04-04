using PetStore.Data;
using PetStore.Models;
using Microsoft.EntityFrameworkCore;

namespace PetStore.Services;

public class PetService
{
  private readonly PetStoreContext _context;

  public PetService(PetStoreContext context)
  {
    _context = context;
  }

  public List<Pet> GetAllPets()
  {
    return _context.Pets.ToList();
  }

  public List<Pet> GetPetsByCategory(string? category)
  {
    if (string.IsNullOrWhiteSpace(category))
    {
      return new List<Pet>();
    }

    return _context.Pets
      .Where(p => p.Type.ToLower() == category.ToLower())
      .ToList();
  }

  public Pet? GetPetById(string id)
  {
    return _context.Pets.FirstOrDefault(p => p.Id == id);
  }

  public void AddPet(Pet pet)
  {
    pet.Type = pet.Type.Trim().ToLower();

    _context.Pets.Add(pet);
    _context.SaveChanges();
  }

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

  public void DeletePet(string id)
  {
    var pet = _context.Pets.FirstOrDefault(p => p.Id == id);

    if (pet != null)
    {
      _context.Pets.Remove(pet);
      _context.SaveChanges();
    }
  }

  public List<PetCategory> GetAllCategories()
  {
    return _context.PetCategories.ToList();
  }

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

  public bool DeleteCategory(int id)
  {
    var category = _context.PetCategories.FirstOrDefault(c => c.Id == id);

    if (category == null)
    {
      return false;
    }

    bool categoryInUse = _context.Pets.Any(p => p.Type.ToLower() == category.Name.ToLower());

    if (categoryInUse)
    {
      return false;
    }

    _context.PetCategories.Remove(category);
    _context.SaveChanges();

    return true;
  }

  public void UpdateCategory(PetCategory updatedCategory)
  {
    var category = _context.PetCategories.FirstOrDefault(c => c.Id == updatedCategory.Id);

    if (category != null)
    {
      string oldName = category.Name;
      string newName = updatedCategory.Name.Trim().ToLower();

      category.Name = newName;

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


  public List<Shelter> GetAllShelters()
  {
    return _context.Shelters.ToList();
  }

  public List<Shelter> GetSheltersByCountry(string? country)
  {
    if (string.IsNullOrWhiteSpace(country))
    {
      return new List<Shelter>();
    }

    return _context.Shelters
      .Where(s => s.Country.ToLower() == country.ToLower())
      .ToList();
  }

  public Shelter? GetShelterById(string id)
  {
    return _context.Shelters.FirstOrDefault(s => s.Id == id);
  }

  public async Task<(int pets, int shelters)> GetGlobalTotalsAsync()
  {
    var petsCount = await _context.Pets.CountAsync();
    var sheltersCount = await _context.Shelters.CountAsync();

    return (petsCount, sheltersCount);
  }
}