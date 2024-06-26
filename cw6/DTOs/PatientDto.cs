﻿namespace cw6.DTOs;

public class PatientDto
{
    private int IdPatient { get; set; }
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public DateTime BirthDate { get; init; }
    public ICollection<PrescriptionData> Prescriptions { get; init; } = null!;
}

public class PrescriptionData
{
    public int IdPrescription { get; init; }
    public DateTime Date { get; init; }
    public DateTime DueDate { get; init; }
    public ICollection<MedicamentData> Medicaments { get; init; } = null!;
    public DoctorData Doctor { get; init; } = null!;
}

public class MedicamentData
{
    public int IdMedicament { get; init; }
    public string Name { get; init; } = null!;
    public string Description { get; init; } = null!;
    public int? Dose { get; init; }
    public string Details { get; init; } = null!;
}

public class DoctorData
{
    public int IdDoctor { get; init; }
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string Email { get; init; } = null!;
}