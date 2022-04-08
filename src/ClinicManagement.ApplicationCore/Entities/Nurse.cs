namespace ClinicManagement.ApplicationCore.Entities;

public class Nurse : Person
{
    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
