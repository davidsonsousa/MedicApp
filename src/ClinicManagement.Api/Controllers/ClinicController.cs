namespace ClinicManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClinicController : ControllerBase
{
    private readonly IClinicService clinicService;

    public ClinicController(IClinicService clinicService)
    {
        this.clinicService = clinicService;
    }

    [HttpGet("id")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var returnValue = await clinicService.GetClinicById(id, cancellationToken);

        return returnValue.HasError ? NotFound() : Ok(returnValue.As<ClinicViewModel>());
    }

    [HttpPost]
    public async Task PostAsync(ClinicEditModel clinicEditModel, CancellationToken cancellationToken)
    {
        await clinicService.SaveAsync(clinicEditModel, cancellationToken);
    }
}
