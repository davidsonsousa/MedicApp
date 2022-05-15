namespace ClinicManagement.ApplicationCore.Models.Requests;

public class WorkScheduleEmployeeRequest : RequestBase
{
    public DateTimeRange DateTimeSchedule { get; set; } = new DateTimeRange();

    public Guid EmployeeId { get; set; }

    public Guid DepartmentId { get; set; }
}
