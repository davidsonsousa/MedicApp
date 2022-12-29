namespace ClinicManagement.Infrastructure.Data;

public class BranchRepository : RepositoryBase<Branch>, IBranchRepository
{
    public BranchRepository(ClinicManagementContext dbContext, ILoggerFactory loggerFactory) : base(dbContext, loggerFactory)
    {
    }

    public async Task<IEnumerable<Branch>> GetAllBranchesWithClinicsAndDepartmentsAsync(CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetAllBranchesWithDepartmentsAsync));

        return await GetValidRecords().Include(b => b.Clinic)
                                      .Include(b => b.Departments.Where(d => d.IsDeleted == false))
                                      .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Branch>> GetAllBranchesWithDepartmentsAsync(CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetAllBranchesWithDepartmentsAsync));

        return await GetValidRecords().Include(b => b.Departments.Where(d => d.IsDeleted == false))
                                      .ToListAsync(cancellationToken);
    }

    public async Task<Branch?> GetBranchWithClinicAndDepartmentsByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetBranchWithClinicAndDepartmentsByIdAsync));

        return await DbContext.Set<Branch>()
                              .Where(q => q.VanityId == id)
                              .Include(b => b.Clinic)
                              .Include(b => b.Departments.Where(d => d.IsDeleted == false))
                              .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<IEnumerable<Branch>> GetBranchesWithClinicAndDepartmentsByClinicIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetBranchesWithClinicAndDepartmentsByClinicIdAsync));

        return await DbContext.Set<Branch>()
                              .Where(q => q.Clinic.VanityId == id)
                              .Include(b => b.Clinic)
                              .Include(b => b.Departments.Where(d => d.IsDeleted == false))
                              .ToListAsync(cancellationToken);
    }
}
