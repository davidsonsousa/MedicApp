namespace ClinicManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
[ApiExplorerSettings(GroupName = "Employees")]
public class NurseController : ControllerBase
{
    private readonly INurseService nurseService;

    public NurseController(INurseService nurseService)
    {
        this.nurseService = nurseService;
    }

    /// <summary>
    /// Gets the list of nurses
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of nurses</returns>
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var result = await nurseService.GetAllNurses(cancellationToken);

        if (result.HasError)
        {
            return NotFound();
        }

        var items = result.As<IEnumerable<NurseResponse>>();

        return !items.Any() ? NotFound() : Ok(items);
    }

    /// <summary>
    /// Gets a nurse by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("id")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var result = await nurseService.GetNurseById(id, cancellationToken);

        return result.HasError ? NotFound() : Ok(result.As<NurseResponse>());
    }

    /// <summary>
    /// Inserts a new nurse
    /// </summary>
    /// <param name="nurseRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPost]
    public async Task PostAsync(NurseRequest nurseRequest, CancellationToken cancellationToken)
    {
        await nurseService.SaveAsync(nurseRequest, cancellationToken);
    }

    /// <summary>
    /// Updates an existing nurse
    /// </summary>
    /// <param name="nurseRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPut]
    public async Task PutAsync(NurseRequest nurseRequest, CancellationToken cancellationToken)
    {
        await nurseService.SaveAsync(nurseRequest, cancellationToken);
    }

    /// <summary>
    /// Deletes an existing nurse
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await nurseService.DeleteAsync(id, cancellationToken);
    }
}
