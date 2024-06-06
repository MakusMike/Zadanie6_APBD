namespace Zadanie6_APBD.DTO;

public class NewPrescriptionRequest
{
    public PatientDto Patient { get; set; }
    public List<MedicamentRequestDto> Medicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}