namespace ClinicManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        this.departmentService = departmentService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var result = await departmentService.GetAllDepartments(cancellationToken);

        if (result.HasError)
        {
            return NotFound();
        }

        var items = result.As<IEnumerable<DepartmentResponse>>();

        return !items.Any() ? NotFound() : Ok(items);
    }

    [HttpGet("id")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var result = await departmentService.GetDepartmentById(id, cancellationToken);

        return result.HasError ? NotFound() : Ok(result.As<DepartmentResponse>());
    }

    [HttpPost]
    public async Task PostAsync(DepartmentRequest departmentRequest, CancellationToken cancellationToken)
    {
        await departmentService.SaveAsync(departmentRequest, cancellationToken);
    }

    [HttpPut]
    public async Task PutAsync(DepartmentRequest departmentRequest, CancellationToken cancellationToken)
    {
        await departmentService.SaveAsync(departmentRequest, cancellationToken);
    }

    [HttpDelete]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await departmentService.DeleteAsync(id, cancellationToken);
    }
}
