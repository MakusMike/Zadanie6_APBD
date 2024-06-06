using Microsoft.EntityFrameworkCore;
using Zadanie6_APBD.Context;
using Zadanie6_APBD.DTO;
using Zadanie6_APBD.Models;

namespace Zadanie6_APBD.Services;

public class PrescriptionService
{
    private readonly AppDbContext _context;

    public PrescriptionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddNewPrescription(NewPrescriptionRequest request)
    {
        if (request.DueDate < request.Date)
            throw new ArgumentException("DueDate must be greater than or equal to Date");

        if (request.Medicaments.Count > 10)
            throw new ArgumentException("A prescription can include a maximum of 10 medicaments");

        var patient = await _context.Patients
            .FirstOrDefaultAsync(p => p.IdPatient == request.Patient.IdPatient);

        if (patient == null)
        {
            patient = new Patient
            {
                FirstName = request.Patient.FirstName,
                LastName = request.Patient.LastName,
                Birthdate = request.Patient.Birthdate
            };
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        var prescription = new Prescription
        {
            Date = request.Date,
            DueDate = request.DueDate,
            IdPatient = patient.IdPatient,
            IdDoctor = request.Patient.IdDoctor
        };

        foreach (var med in request.Medicaments)
        {
            var medicament = await _context.Medicaments
                .FirstOrDefaultAsync(m => m.IdMedicament == med.IdMedicament);

            if (medicament == null)
                throw new ArgumentException($"Medicament with Id {med.IdMedicament} does not exist");

            var prescriptionMedicament = new PrescriptionMedicament
            {
                IdMedicament = med.IdMedicament,
                Medicament = medicament,
                Dose = med.Dose,
                Details = med.Description
            };
            prescription.PrescriptionMedicaments.Add(prescriptionMedicament);
        }

        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();
    }
}