namespace ClinicManagement.Infrastructure.Data;

public class ClinicRepository : RepositoryBase<Clinic>, IClinicRepository
{
    public ClinicRepository(ClinicManagementContext dbContext, ILoggerFactory loggerFactory) : base(dbContext, loggerFactory)
    {
    }
}
