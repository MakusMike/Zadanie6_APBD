using Zadanie6_APBD.DTO;
using Zadanie6_APBD.Repositories;

namespace Zadanie6_APBD.Services;

public class PatientService
{
    private readonly PatientRepository _repository;

    public PatientService(PatientRepository repository)
    {
        _repository = repository;
    }

    public async Task<PatientDto> GetPatientWithDetails(int idPatient)
    {
        return await _repository.GetPatientWithDetails(idPatient);
    }
}