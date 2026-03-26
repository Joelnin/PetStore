using PetStore.Data;
using PetStore.Models;

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
        .Where(p => p.Category.ToLower() == category.ToLower())
        .ToList();
  }

  public Pet? GetPetById(int id)
  {
    return _context.Pets.FirstOrDefault(p => p.Id == id);
  }
}