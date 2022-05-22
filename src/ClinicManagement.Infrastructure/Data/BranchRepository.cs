namespace ClinicManagement.Infrastructure.Data;

public class BranchRepository : RepositoryBase<Branch>, IBranchRepository
{
    public BranchRepository(ClinicManagementContext dbContext, ILoggerFactory loggerFactory) : base(dbContext, loggerFactory)
    {
    }

    public async Task<IEnumerable<Branch>> GetAllBranchesWithDepartmentsAsync(CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetAllBranchesWithDepartmentsAsync));

        return await GetValidRecords().Include(b => b.Departments)
                                      .ToListAsync(cancellationToken);
    }

    public async Task<Branch?> GetBranchWithDepartmentsByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetBranchWithDepartmentsByIdAsync));

        return await DbContext.Set<Branch>()
                              .Where(q => q.VanityId == id)
                              .Include(b => b.Departments)
                              .SingleOrDefaultAsync(cancellationToken);
    }
}
