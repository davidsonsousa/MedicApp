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

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var result = await branchService.GetAllBranches(cancellationToken);

        if (result.HasError)
        {
            return NotFound();
        }

        var items = result.As<IEnumerable<BranchResponse>>();

        return !items.Any() ? NotFound() : Ok(items);
    }

    [HttpGet("id")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var result = await branchService.GetBranchById(id, cancellationToken);

        return result.HasError ? NotFound() : Ok(result.As<BranchResponse>());
    }

    [HttpPost]
    public async Task PostAsync(BranchRequest branchRequest, CancellationToken cancellationToken)
    {
        await branchService.SaveAsync(branchRequest, cancellationToken);
    }

    [HttpPut]
    public async Task PutAsync(BranchRequest branchRequest, CancellationToken cancellationToken)
    {
        await branchService.SaveAsync(branchRequest, cancellationToken);
    }

    [HttpDelete]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await branchService.DeleteAsync(id, cancellationToken);
    }
}
