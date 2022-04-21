namespace ClinicManagement.ApplicationCore.Interfaces.Services;

public interface IBranchService : IService<Branch>
{
    Task<IResult> GetAllBranches(CancellationToken cancellationToken = default);

    Task<IResult> GetBranchById(Guid id, CancellationToken cancellationToken = default);

    Task<IResult> SaveAsync(BranchRequest model, CancellationToken cancellationToken = default);
}
