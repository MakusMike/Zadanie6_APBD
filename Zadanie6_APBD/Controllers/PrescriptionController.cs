using Microsoft.AspNetCore.Mvc;
using Zadanie6_APBD.DTO;
using Zadanie6_APBD.Services;

namespace Zadanie6_APBD.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionController : ControllerBase
{
    private readonly PrescriptionService _prescriptionService;

    public PrescriptionController(PrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }

    [HttpPost]
    public async Task<IActionResult> AddNewPrescription([FromBody] NewPrescriptionRequest request)
    {
        try
        {
            await _prescriptionService.AddNewPrescription(request);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}