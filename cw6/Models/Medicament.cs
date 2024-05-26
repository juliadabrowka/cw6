using System.ComponentModel.DataAnnotations;

namespace cw6.Models;

public class Medicament
{
    [Key, Required] private int IdMedicament{ get; set; }
    [Required, MaxLength(100)] private string Name { get; set; }
    [Required, MaxLength(100)] private string Description { get; set; }
    [Required, MaxLength(100)] private string Type { get; set; }
}