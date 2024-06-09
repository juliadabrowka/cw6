using System.ComponentModel.DataAnnotations;

namespace cw6.Models;

public class Medicament
{
    public int IdMedicament { get; init; }
    public string Name { get; init; } = null!;
    public string Description { get; init; } = null!;
    public string Type { get; init; } = null!;

    public ICollection<Prescription_Medicament> Prescriptions = new List<Prescription_Medicament>();
}