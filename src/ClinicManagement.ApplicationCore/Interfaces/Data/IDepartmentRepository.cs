namespace ClinicManagement.ApplicationCore.Interfaces.Data;

public interface IDepartmentRepository : IRepository<Department>
{
    Task<IEnumerable<Department>> GetAllDepartmentsWithBranchesAsync(CancellationToken cancellationToken = default);

    Task<Department?> GetDepartmentWithBranchByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<Department>> GetDepartmentsWithBranchByBranchIdAsync(Guid id, CancellationToken cancellationToken = default);
}
