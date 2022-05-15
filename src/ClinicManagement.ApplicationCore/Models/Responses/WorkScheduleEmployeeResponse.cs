namespace ClinicManagement.ApplicationCore.Models.Responses;

public class WorkScheduleEmployeeResponse : ResponseBase
{
    public DateTimeRange DateTimeSchedule { get; set; } = new DateTimeRange();

    public Guid EmployeeId { get; set; }

    public Guid DepartmentId { get; set; }
}
