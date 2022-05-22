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

    /// <summary>
    /// Gets the list of clinics
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of clinics</returns>
    [HttpGet]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
    {
        var result = await clinicService.GetAllClinics(cancellationToken);

        if (result.HasError)
        {
            return NotFound();
        }

        var items = result.As<IEnumerable<SimpleClinicResponse>>();

        return !items.Any() ? NotFound() : Ok(items);
    }

    /// <summary>
    /// Gets a clinic by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("id")]
    public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await clinicService.GetClinicById(id, cancellationToken);

        return result.HasError ? NotFound() : Ok(result.As<ClinicResponse>());
    }

    /// <summary>
    /// Inserts a new clinic
    /// </summary>
    /// <param name="clinicRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPost]
    public async Task PostAsync(ClinicRequest clinicRequest, CancellationToken cancellationToken)
    {
        await clinicService.SaveAsync(clinicRequest, cancellationToken);
    }

    /// <summary>
    /// Updates an existing clinic
    /// </summary>
    /// <param name="clinicRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPut]
    public async Task PutAsync(ClinicRequest clinicRequest, CancellationToken cancellationToken)
    {
        await clinicService.SaveAsync(clinicRequest, cancellationToken);
    }

    /// <summary>
    /// Deletes an existing clinic
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await clinicService.DeleteAsync(id, cancellationToken);
    }
}
