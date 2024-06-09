using cw6.DTOs;
using cw6.Models;
using cw6.Repositories;

namespace cw6.Services;

public interface IPatientService
{
    Task<Patient> GetOrAddPatient(PatientData patientData, CancellationToken cancellationToken);
    Task<Patient> GetPatient(int idPatient, CancellationToken cancellationToken);
}

public class PatientService(IPatientRepository patientRepository) : IPatientService
{
    private readonly IPatientRepository _patientRepository = patientRepository;

    public async Task<Patient> GetOrAddPatient(PatientData patientData, CancellationToken cancellationToken)
    {
        return await _patientRepository.GetOrAddPatient(patientData, cancellationToken);
    }

    public async Task<Patient> GetPatient(int idPatient, CancellationToken cancellationToken)
    {
        return await _patientRepository.GetPatient(idPatient, cancellationToken);
    }
}