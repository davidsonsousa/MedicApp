namespace ClinicManagement.ApplicationCore.Entities;

public class Branch : EntityBase
{
    [Column(Order = 11)]
    public long ClinicId { get; set; }

    public virtual Clinic Clinic { get; set; } = null!;

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    [Column(Order = 20)]
    public string Name { get; set; } = string.Empty;

    public Address Address { get; set; } = null!;

    public PhoneNumber PhoneNumber { get; set; } = null!;
}
