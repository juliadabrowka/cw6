using cw6.Models;
using Microsoft.EntityFrameworkCore;

namespace cw6.Repositories;

public interface IMedicamentRepository
{
    public Task<Medicament> GetMedicament(string name, CancellationToken cancellationToken);
}

public class MedicamentRepository(Context.Context context) : IMedicamentRepository
{
    private readonly Context.Context _context = context;

    public async Task<Medicament> GetMedicament(string name, CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        try
        {
            return await _context.Medicament.SingleAsync(medicament => medicament.Name == name, cancellationToken);
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException($"Medicament {name} not found");
        }
    }
}