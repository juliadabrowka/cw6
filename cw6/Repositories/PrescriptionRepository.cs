using cw6.Models;

namespace cw6.Repositories;

public interface IPrescriptionRepository
{
    Task AddPrescription(Models.Prescription prescription, CancellationToken cancellationToken);
    Task AddPrescriptionMedicament(Prescription_Medicament prescriptionMedicament, CancellationToken cancellationToken);
}

public class PrescriptionRepository(Context.Context context) : IPrescriptionRepository
{
    private readonly Context.Context _context = context;

    public async Task AddPrescription(Models.Prescription prescription, CancellationToken cancellationToken)
    {
        await _context.Prescription.AddAsync(prescription, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task AddPrescriptionMedicament(Prescription_Medicament prescriptionMedicament, CancellationToken cancellationToken)
    {
        await _context.Prescription_Medicament.AddAsync(prescriptionMedicament, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}