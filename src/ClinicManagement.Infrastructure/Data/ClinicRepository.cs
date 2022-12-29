namespace ClinicManagement.Infrastructure.Data;

public class ClinicRepository : RepositoryBase<Clinic>, IClinicRepository
{
    public ClinicRepository(ClinicManagementContext dbContext, ILoggerFactory loggerFactory) : base(dbContext, loggerFactory)
    {
    }

    public async Task<IEnumerable<Clinic>> GetAllClinicsWithBranchesAsync(CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetAllClinicsWithBranchesAsync));

        return await GetValidRecords().Include(c => c.Branches.Where(b => b.IsDeleted == false))
                                      .ToListAsync(cancellationToken);
    }

    public async Task<Clinic?> GetClinicWithBranchesByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Logger.DebugMethodCall(nameof(GetClinicWithBranchesByIdAsync));

        return await DbContext.Set<Clinic>()
                              .Where(q => q.VanityId == id)
                              .Include(c => c.Branches.Where(b => b.IsDeleted == false))
                              .SingleOrDefaultAsync(cancellationToken);
    }
}
