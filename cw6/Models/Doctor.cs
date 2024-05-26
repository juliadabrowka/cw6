using System.ComponentModel.DataAnnotations;

namespace cw6.Models;

public class Doctor
{
    [Key, Required] private int IdDoctor { get; set; }
    [Required, MaxLength(100)] private string FirstName { get; set; }
    [Required, MaxLength(100)] private string LastName { get; set; }
    [Required, MaxLength(100)] private string Email { get; set; }
}