using cw6.Models;
using Microsoft.EntityFrameworkCore;

namespace cw6.Repositories;

public interface IDoctorRepository
{
    Task<Doctor> GetDoctor(int idDoctor, CancellationToken cancellationToken);
}

public class DoctorRepository(Context.Context context) : IDoctorRepository
{
    private readonly Context.Context _context = context;

    public async Task<Doctor> GetDoctor(int idDoctor, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Doctor.SingleAsync(doctor => doctor.IdDoctor == idDoctor, cancellationToken);
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException($"Doctor id {idDoctor} not found");
        }
    }
}