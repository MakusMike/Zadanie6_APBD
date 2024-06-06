using Microsoft.AspNetCore.Mvc;
using Zadanie6_APBD.Services;

namespace Zadanie6_APBD.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly PatientService _patientService;

    public PatientsController(PatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientWithDetails(int id)
    {
        var patient = await _patientService.GetPatientWithDetails(id);

        if (patient == null)
            return NotFound();

        return Ok(patient);
    }
}