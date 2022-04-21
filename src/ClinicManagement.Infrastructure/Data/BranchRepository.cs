namespace ClinicManagement.Infrastructure.Data;

public class BranchRepository : RepositoryBase<Branch>, IBranchRepository
{
    public BranchRepository(ClinicManagementContext dbContext, ILoggerFactory loggerFactory) : base(dbContext, loggerFactory)
    {
    }
}
