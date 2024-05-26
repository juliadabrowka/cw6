using System.ComponentModel.DataAnnotations;

namespace cw6.Models;

public class Prescription_Medicament
{
    [Key, Required] private int IdMedicament { get; set; }
    [Key, Required] private int IdPrescription { get; set; }
    private int Dose { get; set; }
    [Required, MaxLength(100)] private string Details { get; set; }
}