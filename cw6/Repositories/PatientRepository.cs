using cw6.DTOs;
using cw6.Models;
using Microsoft.EntityFrameworkCore;

namespace cw6.Repositories;

public interface IPatientRepository
{
    Task<Patient> GetOrAddPatient(PatientData patientData, CancellationToken cancellationToken);
    Task<Patient> GetPatient(int idPatient, CancellationToken cancellationToken);
}

public class PatientRepository(Context.Context context) : IPatientRepository
{
    private readonly Context.Context _context = context;

    public async Task<Patient> GetOrAddPatient(PatientData patientData, CancellationToken cancellationToken)
    {
        var existingPatient = await _context.Patient.FirstOrDefaultAsync(
            patient =>
                patient.BirthDate == patientData.BirthDate &&
                patient.LastName == patientData.LastName &&
                patient.FirstName == patientData.FirstName,
            cancellationToken);

        if (existingPatient != null)
        {
            return existingPatient;
        }

        var newPatient = new Patient(patientData);
        await _context.Patient.AddAsync(newPatient, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return newPatient;
    }

    public async Task<Patient> GetPatient(int idPatient, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Patient
                .Include(patient => patient.Prescriptions)
                .ThenInclude(prescription => prescription.Medicaments)
                .ThenInclude(prescriptionMedicament => prescriptionMedicament.Medicament)
                .Include(patient => patient.Prescriptions)
                .ThenInclude(prescription => prescription.Doctor)
                .SingleAsync(patient => patient.IdPatient == idPatient, cancellationToken);
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException($"Patient id {idPatient} not found");
        }
    }
}