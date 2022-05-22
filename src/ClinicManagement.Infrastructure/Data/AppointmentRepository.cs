namespace ClinicManagement.Infrastructure.Data;

public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
{
    public AppointmentRepository(ClinicManagementContext dbContext, ILoggerFactory loggerFactory) : base(dbContext, loggerFactory)
    {
    }

    public async Task<IEnumerable<Appointment>> GetAppointmentsWithPatientAsync(CancellationToken cancellationToken)
    {
        return await GetValidRecords().Include(ws => ws.Person)
                                      .ToListAsync(cancellationToken);
    }
}
