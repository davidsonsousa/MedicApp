namespace ClinicManagement.ApplicationCore.Interfaces.Services;

public interface IDepartmentService : IService<Department>
{
    Task<IResult> GetAllDepartments(CancellationToken cancellationToken = default);

    Task<IResult> GetDepartmentById(Guid id, CancellationToken cancellationToken = default);

    Task<IResult> GetDepartmentsByBranchId(Guid id, CancellationToken cancellationToken = default);

    Task<IResult> SaveAsync(DepartmentRequest model, CancellationToken cancellationToken = default);
}
