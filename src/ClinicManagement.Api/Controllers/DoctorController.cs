namespace ClinicManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
[ApiExplorerSettings(GroupName = "Personnel")]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        this.doctorService = doctorService;
    }
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var result = await doctorService.GetAllDoctors(cancellationToken);

        if (result.HasError)
        {
            return NotFound();
        }

        var items = result.As<IEnumerable<DoctorResponse>>();

        return !items.Any() ? NotFound() : Ok(items);
    }

    [HttpGet("id")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var result = await doctorService.GetDoctorById(id, cancellationToken);

        return result.HasError ? NotFound() : Ok(result.As<DoctorResponse>());
    }

    [HttpPost]
    public async Task PostAsync(DoctorRequest doctorRequest, CancellationToken cancellationToken)
    {
        await doctorService.SaveAsync(doctorRequest, cancellationToken);
    }

    [HttpPut]
    public async Task PutAsync(DoctorRequest doctorRequest, CancellationToken cancellationToken)
    {
        await doctorService.SaveAsync(doctorRequest, cancellationToken);
    }

    [HttpDelete]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await doctorService.DeleteAsync(id, cancellationToken);
    }
}
