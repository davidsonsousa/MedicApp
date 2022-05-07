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

    /// <summary>
    /// Gets the list of departments
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of departments</returns>
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

    /// <summary>
    /// Gets a department by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("id")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var result = await departmentService.GetDepartmentById(id, cancellationToken);

        return result.HasError ? NotFound() : Ok(result.As<DepartmentResponse>());
    }

    /// <summary>
    /// Inserts a new department
    /// </summary>
    /// <param name="departmentRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPost]
    public async Task PostAsync(DepartmentRequest departmentRequest, CancellationToken cancellationToken)
    {
        await departmentService.SaveAsync(departmentRequest, cancellationToken);
    }

    /// <summary>
    /// Updates an existing department
    /// </summary>
    /// <param name="departmentRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPut]
    public async Task PutAsync(DepartmentRequest departmentRequest, CancellationToken cancellationToken)
    {
        await departmentService.SaveAsync(departmentRequest, cancellationToken);
    }

    /// <summary>
    /// Deletes an existing department
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await departmentService.DeleteAsync(id, cancellationToken);
    }
}
