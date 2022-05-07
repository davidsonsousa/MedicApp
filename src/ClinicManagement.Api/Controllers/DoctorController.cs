namespace ClinicManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
[ApiExplorerSettings(GroupName = "Employees")]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        this.doctorService = doctorService;
    }

    /// <summary>
    /// Gets the list of doctors
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of doctors</returns>
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

    /// <summary>
    /// Gets a doctor by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("id")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var result = await doctorService.GetDoctorById(id, cancellationToken);

        return result.HasError ? NotFound() : Ok(result.As<DoctorResponse>());
    }

    /// <summary>
    /// Inserts a new doctor
    /// </summary>
    /// <param name="doctorRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPost]
    public async Task PostAsync(DoctorRequest doctorRequest, CancellationToken cancellationToken)
    {
        await doctorService.SaveAsync(doctorRequest, cancellationToken);
    }

    /// <summary>
    /// Updates an existing doctor
    /// </summary>
    /// <param name="doctorRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPut]
    public async Task PutAsync(DoctorRequest doctorRequest, CancellationToken cancellationToken)
    {
        await doctorService.SaveAsync(doctorRequest, cancellationToken);
    }

    /// <summary>
    /// Deletes an existing doctor
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await doctorService.DeleteAsync(id, cancellationToken);
    }
}
