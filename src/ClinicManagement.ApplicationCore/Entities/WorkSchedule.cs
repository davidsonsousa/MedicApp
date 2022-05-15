namespace ClinicManagement.ApplicationCore.Entities;

public class WorkSchedule : ScheduleItem
{
    [Column(Order = 12)]
    public long DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;
}
