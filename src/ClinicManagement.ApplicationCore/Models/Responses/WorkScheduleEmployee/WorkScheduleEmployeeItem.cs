namespace ClinicManagement.ApplicationCore.Models.Responses.WorkScheduleEmployee;

public class WorkScheduleEmployeeItem
{
    public Guid VanityId { get; set; }

    public DateTimeRange DateTimeSchedule { get; set; } = new DateTimeRange();

    public Guid EmployeeId { get; set; }

    public Guid DepartmentId { get; set; }
}
