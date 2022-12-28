namespace ClinicManagement.Infrastructure.Data;

public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
{
    public DepartmentRepository(ClinicManagementContext dbContext, ILoggerFactory loggerFactory) : base(dbContext, loggerFactory)
    {
    }

    public async Task<IEnumerable<Department>> GetDepartmentsWithBranchByBranchIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetDepartmentsWithBranchByBranchIdAsync));

        return await DbContext.Set<Department>()
                              .Where(q => q.Branch.VanityId == id)
                              .Include(d => d.Branch)
                              .ToListAsync(cancellationToken);
    }

    public async Task<Department?> GetDepartmentWithBranchByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetDepartmentWithBranchByIdAsync));

        return await DbContext.Set<Department>()
                              .Where(q => q.VanityId == id)
                              .Include(d => d.Branch)
                              .SingleOrDefaultAsync(cancellationToken);
    }
}
