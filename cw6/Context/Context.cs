using cw6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace cw6.Context;

public partial class Context : DbContext
{
    public Context(){}
    public Context(DbContextOptions<Context> options): base(options) {}
    
    public virtual DbSet<Doctor> Doctor { get; set; }
    public virtual DbSet<Medicament> Medicament { get; set; }
    public virtual DbSet<Prescription_Medicament> Prescription_Medicament { get; set; }
    public virtual DbSet<Prescription> Prescription { get; set; }
    public virtual DbSet<Patient> Patient { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseSqlServer("Data Source=localhost;Initial Catalog=APBD;User ID=sa;Password=asd123POKo223;Encrypt=False")
            .LogTo(Console.WriteLine, LogLevel.Information);
}