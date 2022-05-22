namespace ClinicManagement.ApplicationCore.Interfaces.Data;

public interface IBranchRepository : IRepository<Branch>
{
    Task<IEnumerable<Branch>> GetAllBranchesWithDepartmentsAsync(CancellationToken cancellationToken = default);

    Task<Branch?> GetBranchWithDepartmentsByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
