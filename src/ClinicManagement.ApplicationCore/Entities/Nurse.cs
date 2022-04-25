namespace ClinicManagement.ApplicationCore.Entities;

public class Nurse : Person
{
    public virtual ICollection<Department> Departments { get; set; } = null!;

    public virtual ICollection<WorkSchedule> WorkSchedules { get; set; } = null!;
}
