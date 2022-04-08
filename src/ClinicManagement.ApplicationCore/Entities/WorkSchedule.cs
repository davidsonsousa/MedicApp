namespace ClinicManagement.ApplicationCore.Entities;

public class WorkSchedule : ScheduleItem
{
    public long DepartmentId { get; set; }

    public virtual Department Department { get; set; } = new Department();
}
