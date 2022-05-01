namespace ClinicManagement.Infrastructure.Data;

public abstract class EmployeeRepository<TEntity> : PersonRepository<TEntity>, IEmployeeRepository<TEntity> where TEntity : Employee
{
    public EmployeeRepository(ClinicManagementContext dbContext, ILoggerFactory loggerFactory) : base(dbContext, loggerFactory)
    {
    }

    public async Task AddDepartmentsToEmployeeAsync(TEntity? employee, IEnumerable<Department>? departments, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(employee, nameof(employee));
        Guard.Against.Null(departments, nameof(departments));

        Logger.DebugMethodCall(nameof(AddDepartmentsToEmployeeAsync));

        if (!departments.Any())
        {
            Logger.LogDebug("No department to add to employee");
            return;
        }

        var departmentEmployeeList = departments.Select(dept => new DepartmentEmployee
        {
            DepartmentId = dept.Id,
            EmployeeId = employee.Id
        });

        await DbContext.Set<DepartmentEmployee>().AddRangeAsync(departmentEmployeeList, cancellationToken);
    }

    public async Task<TEntity?> GetEmployeeWithDepartmentsAndLanguagesById(Guid id, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetEmployeeWithDepartmentsAndLanguagesById), id);

        return await DbContext.Set<TEntity>()
                              .Include(d => d.Departments)
                              .Include(d => d.Languages)
                              .AsSplitQuery()
                              .SingleOrDefaultAsync(q => q.VanityId == id, cancellationToken);
    }

    public async Task RemoveDepartmentsFromEmployeeAsync(TEntity? employee, IEnumerable<Department>? departments, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(employee, nameof(employee));
        Guard.Against.Null(departments, nameof(departments));

        Logger.DebugMethodCall(nameof(RemoveDepartmentsFromEmployeeAsync));

        var departmentEmployeeList = await DbContext.Set<DepartmentEmployee>()
                                                  .Where(dd => dd.EmployeeId == employee.Id && departments.Select(d => d.Id).Contains(dd.DepartmentId))
                                                  .ToListAsync(cancellationToken);

        if (departmentEmployeeList is not null)
        {
            DbContext.RemoveRange(departmentEmployeeList);
            await DbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task UpdateEmployeeDepartmentsAsync(TEntity? employee, IEnumerable<Department>? departmentsToAdd, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(employee, nameof(employee));

        Logger.DebugMethodCall(nameof(UpdateEmployeeDepartmentsAsync));

        await RemoveDepartmentsFromEmployeeAsync(employee, employee.Departments, cancellationToken);
        await AddDepartmentsToEmployeeAsync(employee, departmentsToAdd, cancellationToken);
    }
}
