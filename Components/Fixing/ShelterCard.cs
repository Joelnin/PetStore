using System.ComponentModel.DataAnnotations;

namespace PetStore
{
  public class ShelterCard
  {
    public required string Name { get; set; }

    public required string Specialty { get; set; }

    public required string Location { get; set; }

    public string? Email { get; set; }

    public bool IsFlipped { get; set; }

  }
}



