namespace ClinicManagement.ApplicationCore.Entities;

public class Branch : Entity
{
    [Column(Order = 2)]
    public string Name { get; set; } = string.Empty;

    public Address Address { get; set; } = new Address();

    public long ClinicId { get; set; }

    public virtual Clinic Clinic { get; set; } = new Clinic();

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
