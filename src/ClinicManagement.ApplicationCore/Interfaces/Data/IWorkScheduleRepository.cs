namespace ClinicManagement.ApplicationCore.Interfaces.Data;

public interface IWorkScheduleRepository : IRepository<WorkSchedule>
{
    Task<IEnumerable<WorkSchedule>> GetWorkSchedulesWithEmployeeAndDepartmentAsync(CancellationToken cancellationToken);

    Task<IEnumerable<WorkSchedule>> GetWorkSchedulesWithEmployeeAndDepartmentByEmployeeTypeAsync(string employeeType, CancellationToken cancellationToken);
}
