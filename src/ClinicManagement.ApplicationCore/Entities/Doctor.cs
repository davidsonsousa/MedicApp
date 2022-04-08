namespace ClinicManagement.ApplicationCore.Entities;

public class Doctor : Person
{
    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
