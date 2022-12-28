namespace ClinicManagement.ApplicationCore.Interfaces.Data;

public interface IDepartmentRepository : IRepository<Department>
{
    Task<Department?> GetDepartmentWithBranchByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<Department>> GetDepartmentsWithBranchByBranchIdAsync(Guid id, CancellationToken cancellationToken = default);
}
