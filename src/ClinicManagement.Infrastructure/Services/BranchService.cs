namespace ClinicManagement.Infrastructure.Services;

public class BranchService : ServiceBase<Branch>, IBranchService
{
    private readonly IBranchRepository branchRepository;
    private readonly IClinicRepository clinicRepository;

    public BranchService(IBranchRepository branchRepository, IClinicRepository clinicRepository, ILoggerFactory loggerFactory)
        : base(branchRepository, loggerFactory)
    {
        this.branchRepository = branchRepository;
        this.clinicRepository = clinicRepository;
    }

    public async Task<IResult> GetAllBranches(CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetAllBranches));
        var result = new Result<IEnumerable<BranchResponse>>();

        try
        {
            var branches = await branchRepository.GetAllBranchesWithDepartmentsAsync(cancellationToken);
            Guard.Against.Null(branches, nameof(branches));

            result.Value = branches.MapToResponse();
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(BranchService), nameof(GetAllBranches));
            result.SetErrorMessage("An error has occurred while loading the branches");
        }

        return result;
    }

    public async Task<IResult> GetBranchById(Guid id, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(BranchService), nameof(GetBranchById), id);
        var result = new Result<BranchDetailResponse>();

        try
        {
            var branch = await branchRepository.GetBranchWithDepartmentsByIdAsync(id, cancellationToken);
            Guard.Against.Null(branch, nameof(branch));

            result.Value = branch.MapToResponse();
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(BranchService), nameof(GetBranchById));
            result.SetErrorMessage("An error has occurred while loading the branch");
        }

        return result;
    }

    public async Task<IResult> SaveAsync(BranchRequest model, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(BranchService), nameof(SaveAsync), model);
        var result = new Result($"Branch '{model.Name}' saved.");

        try
        {
            await AddOrUpdateAsync(model, cancellationToken);
            await Repository.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.ErrorMethodCall(ex, nameof(BranchService), nameof(GetBranchById));
            result.SetErrorMessage("An error has occurred while saving the branch");
        }

        return result;
    }

    private async Task AddOrUpdateAsync(BranchRequest model, CancellationToken cancellationToken = default)
    {
        if (model.IsNew)
        {
            var branch = model.MapToEntity(await clinicRepository.GetByIdAsync(model.ClinicId, cancellationToken));
            await Repository.AddAsync(branch, cancellationToken);
        }
        else
        {
            var branch = model.MapToEntity(await Repository.GetByIdAsync(model.VanityId, cancellationToken),
                                           await clinicRepository.GetByIdAsync(model.ClinicId, cancellationToken));
            Repository.Update(branch, cancellationToken);
        }
    }
}
