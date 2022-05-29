namespace ClinicManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BranchController : ControllerBase
{
    private readonly IBranchService branchService;

    public BranchController(IBranchService branchService)
    {
        this.branchService = branchService;
    }

    /// <summary>
    /// Gets the list of branches
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of branches</returns>
    [HttpGet]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
    {
        var result = await branchService.GetAllBranches(cancellationToken);

        if (result.HasError)
        {
            return NotFound();
        }

        var items = result.As<IEnumerable<BranchResponse>>();

        return !items.Any() ? NotFound() : Ok(items);
    }

    /// <summary>
    /// Gets a branch by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await branchService.GetBranchById(id, cancellationToken);

        return result.HasError ? NotFound() : Ok(result.As<BranchDetailResponse>());
    }

    /// <summary>
    /// Inserts a new branch
    /// </summary>
    /// <param name="branchRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPost]
    public async Task PostAsync(BranchRequest branchRequest, CancellationToken cancellationToken)
    {
        await branchService.SaveAsync(branchRequest, cancellationToken);
    }

    /// <summary>
    /// Updates an existing branch
    /// </summary>
    /// <param name="branchRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPut]
    public async Task PutAsync(BranchRequest branchRequest, CancellationToken cancellationToken)
    {
        await branchService.SaveAsync(branchRequest, cancellationToken);
    }

    /// <summary>
    /// Deletes an existing branch
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await branchService.DeleteAsync(id, cancellationToken);
    }
}
