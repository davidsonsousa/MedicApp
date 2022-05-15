namespace ClinicManagement.Infrastructure.Data;

public class WorkScheduleRepository : RepositoryBase<WorkSchedule>, IWorkScheduleRepository
{
    public WorkScheduleRepository(ClinicManagementContext dbContext, ILoggerFactory loggerFactory) : base(dbContext, loggerFactory)
    {
    }

    public async Task<IEnumerable<WorkSchedule>> GetWorkSchedulesWithEmployeeAndDepartmentAsync(CancellationToken cancellationToken)
    {
        return await GetValidRecords().Include(ws => ws.Person)
                                      .Include(ws => ws.Department)
                                      .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<WorkSchedule>> GetWorkSchedulesWithEmployeeAndDepartmentByEmployeeTypeAsync(string employeeType, CancellationToken cancellationToken)
    {
        return await GetValidRecords().Include(ws => ws.Person)
                                      .Include(ws => ws.Department)
                                      .Where(ws => ws.Person.Discriminator == employeeType)
                                      .ToListAsync(cancellationToken);
    }
}
