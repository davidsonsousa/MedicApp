namespace ClinicManagement.Infrastructure.Data;

public class NurseRepository : EmployeeRepository<Nurse>, INurseRepository
{
    public NurseRepository(ClinicManagementContext dbContext, ILoggerFactory loggerFactory) : base(dbContext, loggerFactory)
    {
    }
}
