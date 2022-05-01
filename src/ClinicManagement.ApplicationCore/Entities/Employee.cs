namespace ClinicManagement.ApplicationCore.Entities;

public abstract class Employee : Person
{
    public virtual ICollection<Department> Departments { get; set; } = null!;

    public virtual ICollection<WorkSchedule> WorkSchedules { get; set; } = null!;
}
