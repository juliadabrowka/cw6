using cw6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace cw6.Context;

public partial class Context : DbContext
{
    private const string Schema = "prsp";
    public Context(){}
    public Context(DbContextOptions<Context> options): base(options) {}
    
    public virtual DbSet<Doctor> Doctor { get; set; }
    public virtual DbSet<Medicament> Medicament { get; set; }
    public virtual DbSet<Prescription_Medicament> Prescription_Medicament { get; set; }
    public virtual DbSet<Prescription> Prescription { get; set; }
    public virtual DbSet<Patient> Patient { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     => optionsBuilder
    //         .UseSqlServer("Data Source=localhost;Initial Catalog=APBD;User ID=sa;Password=asd123POKo223;Encrypt=False")
    //         .LogTo(Console.WriteLine, LogLevel.Information);
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription).HasName("PK_Prescription");

                entity.ToTable(nameof(Models.Prescription), Schema);

                entity.Property(e => e.IdPrescription).ValueGeneratedOnAdd();
                entity.Property(e => e.Date);
                entity.Property(e => e.DueDate);
                entity.HasOne(e => e.Doctor)
                    .WithMany(c => c.Prescriptions)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(e => e.Patient)
                    .WithMany(c => c.Prescriptions)
                    .HasForeignKey(d => d.IdPatient)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            }
        );

        modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor).HasName("PK_Doctor");

                entity.ToTable(nameof(Doctor), Schema);

                entity.Property(e => e.IdDoctor).ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).HasMaxLength(100);
                entity.Property(e => e.LastName).HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(100);
            }
        );

        modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient).HasName("PK_Patient");

                entity.ToTable(nameof(Patient), Schema);

                entity.Property(e => e.IdPatient).ValueGeneratedOnAdd();
                entity.Property(e => e.FirstName).HasMaxLength(100);
                entity.Property(e => e.LastName).HasMaxLength(100);
                entity.Property(e => e.BirthDate);
            }
        );

        modelBuilder.Entity<Prescription_Medicament>(entity =>
            {
                entity.HasKey(e => new{e.IdPrescription, e.IdMedicament}).HasName("PK_Prescription_Medicament");

                entity.ToTable(nameof(Prescription_Medicament), Schema);

                entity.Property(e => e.IdPrescription).ValueGeneratedNever();
                entity.Property(e => e.IdMedicament).ValueGeneratedNever();
                entity.Property(e => e.Dose).IsRequired(false);
                entity.Property(e => e.Details).HasMaxLength(100);
                entity.HasOne(e => e.Medicament)
                    .WithMany(c => c.Prescriptions)
                    .HasForeignKey(d => d.IdMedicament)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(e => e.Prescription)
                    .WithMany(c => c.Medicaments)
                    .HasForeignKey(d => d.IdPrescription)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            }
        );

        modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament).HasName("PK_Medicament");

                entity.ToTable(nameof(Medicament), Schema);

                entity.Property(e => e.IdMedicament).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(100);
                entity.Property(e => e.Type).HasMaxLength(100);
            }
        );
    }
}