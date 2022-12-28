namespace ClinicManagement.ApplicationCore.Interfaces.Data;

public interface IBranchRepository : IRepository<Branch>
{
    Task<IEnumerable<Branch>> GetAllBranchesWithClinicsAndDepartmentsAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<Branch>> GetAllBranchesWithDepartmentsAsync(CancellationToken cancellationToken = default);

    Task<Branch?> GetBranchWithClinicAndDepartmentsByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<Branch>> GetBranchesWithClinicAndDepartmentsByClinicIdAsync(Guid id, CancellationToken cancellationToken = default);
}
