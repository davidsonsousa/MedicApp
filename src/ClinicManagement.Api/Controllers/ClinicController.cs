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

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var returnValue = await clinicService.GetAllClinics(cancellationToken);

        return returnValue.HasError ? NotFound() : Ok(returnValue.As<IEnumerable<ClinicViewModel>>());
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

    [HttpPut]
    public async Task PutAsync(ClinicEditModel clinicEditModel, CancellationToken cancellationToken)
    {
        await clinicService.SaveAsync(clinicEditModel, cancellationToken);
    }

    [HttpDelete]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await clinicService.DeleteAsync(id, cancellationToken);
    }
}
