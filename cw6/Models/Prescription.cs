using System.ComponentModel.DataAnnotations;

namespace cw6.Models;

public class Prescription
{
    [Key, Required] public int IdPrescription { get; set; }
    [Required] private DateTime Date { get; set; }
    [Required] private DateTime DueDate { get; set; }
    [Required] private int IdPatient { get; set; }
    [Required] private int IdDoctor { get; set; }
}