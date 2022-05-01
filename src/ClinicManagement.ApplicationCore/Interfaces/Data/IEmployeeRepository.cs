namespace ClinicManagement.ApplicationCore.Interfaces.Data;

public interface IEmployeeRepository<TEntity> : IPersonRepository<TEntity>, IRepository<TEntity> where TEntity : Employee
{
    Task AddDepartmentsToEmployeeAsync(TEntity? employee, IEnumerable<Department>? departments, CancellationToken cancellationToken = default);

    Task<TEntity?> GetEmployeeWithDepartmentsAndLanguagesById(Guid id, CancellationToken cancellationToken = default);

    Task RemoveDepartmentsFromEmployeeAsync(TEntity? employee, IEnumerable<Department>? departments, CancellationToken cancellationToken = default);

    Task UpdateEmployeeDepartmentsAsync(TEntity? employee, IEnumerable<Department>? departments, CancellationToken cancellationToken = default);

}
