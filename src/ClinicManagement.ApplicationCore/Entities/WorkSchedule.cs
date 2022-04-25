namespace ClinicManagement.ApplicationCore.Entities;

public class WorkSchedule : ScheduleItem
{
    public long DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; set; } = null!;

    public virtual ICollection<Nurse> Nurses { get; set; } = null!;
}
