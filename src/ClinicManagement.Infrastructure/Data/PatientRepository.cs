namespace ClinicManagement.Infrastructure.Data;

public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
{
    public PatientRepository(ClinicManagementContext dbContext, ILoggerFactory loggerFactory) : base(dbContext, loggerFactory)
    {
    }
}
