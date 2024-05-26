namespace cw6.Controllers;
using cw6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionController : ControllerBase
{
    private readonly Context.Context _context;

    public PrescriptionController(Context.Context context)
    {
        _context = context;
    }
    // GET: api/Prescription/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Prescription>> GetPrescription(int id)
    {
        var prescription = await _context.Prescription.FindAsync(id);

        if (prescription == null)
        {
            return NotFound();
        }

        return prescription;
    }
    
    
    // POST: api/Prescription
    [HttpPost]
    public async Task<ActionResult<Prescription>> PostClient(Prescription prescription)
    {
        _context.Prescription.Add(prescription);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPrescription", new { id = prescription.IdPrescription }, prescription);
    }
}