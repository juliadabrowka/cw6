using System.ComponentModel.DataAnnotations;

namespace cw6.Models;

public class Patient
{
    [Key, Required] private int IdPatient { get; set; }
    [Required, MaxLength(100)] private string FirstName { get; set; }
    [Required, MaxLength(100)] private string LastName { get; set; }
    [Required] private DateTime Birthdate { get; set; }
}