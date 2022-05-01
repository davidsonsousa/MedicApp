namespace ClinicManagement.Infrastructure.Data;

public class DoctorRepository : EmployeeRepository<Doctor>, IDoctorRepository
{
    public DoctorRepository(ClinicManagementContext dbContext, ILoggerFactory loggerFactory) : base(dbContext, loggerFactory)
    {
    }
}
