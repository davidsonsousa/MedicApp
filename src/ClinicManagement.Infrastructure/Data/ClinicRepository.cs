namespace ClinicManagement.Infrastructure.Data;

public class ClinicRepository : RepositoryBase<Clinic>, IClinicRepository
{
    public ClinicRepository(ClinicManagementContext dbContext, ILoggerFactory loggerFactory) : base(dbContext, loggerFactory)
    {
    }

    public async Task<IEnumerable<Clinic>> GetAllClinicsWithBranchesAsync(CancellationToken cancellationToken = default)
    {
        return await GetValidRecords().Include(c => c.Branches)
                                      .ToListAsync(cancellationToken);
    }
}
