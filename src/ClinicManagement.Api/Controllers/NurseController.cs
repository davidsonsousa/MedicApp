namespace ClinicManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
[ApiExplorerSettings(GroupName = "Personnel")]
public class NurseController : ControllerBase
{
    private readonly INurseService nurseService;

    public NurseController(INurseService nurseService)
    {
        this.nurseService = nurseService;
    }
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

    [HttpGet("id")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var result = await nurseService.GetNurseById(id, cancellationToken);

        return result.HasError ? NotFound() : Ok(result.As<NurseResponse>());
    }

    [HttpPost]
    public async Task PostAsync(NurseRequest nurseRequest, CancellationToken cancellationToken)
    {
        await nurseService.SaveAsync(nurseRequest, cancellationToken);
    }

    [HttpPut]
    public async Task PutAsync(NurseRequest nurseRequest, CancellationToken cancellationToken)
    {
        await nurseService.SaveAsync(nurseRequest, cancellationToken);
    }

    [HttpDelete]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await nurseService.DeleteAsync(id, cancellationToken);
    }
}
