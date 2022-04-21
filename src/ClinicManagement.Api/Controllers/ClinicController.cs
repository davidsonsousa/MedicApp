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
        var result = await clinicService.GetAllClinics(cancellationToken);

        if (result.HasError)
        {
            return NotFound();
        }

        var items = result.As<IEnumerable<ClinicResponse>>();

        return !items.Any() ? NotFound() : Ok(items);
    }

    [HttpGet("id")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var result = await clinicService.GetClinicById(id, cancellationToken);

        return result.HasError ? NotFound() : Ok(result.As<ClinicResponse>());
    }

    [HttpPost]
    public async Task PostAsync(ClinicRequest clinicRequest, CancellationToken cancellationToken)
    {
        await clinicService.SaveAsync(clinicRequest, cancellationToken);
    }

    [HttpPut]
    public async Task PutAsync(ClinicRequest clinicRequest, CancellationToken cancellationToken)
    {
        await clinicService.SaveAsync(clinicRequest, cancellationToken);
    }

    [HttpDelete]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await clinicService.DeleteAsync(id, cancellationToken);
    }
}
