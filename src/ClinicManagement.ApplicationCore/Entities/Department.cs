namespace ClinicManagement.ApplicationCore.Entities;

public class Department : EntityBase
{
    [Column(Order = 11)]
    public long BranchId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = null!;

    [Column(Order = 20)]
    public string Name { get; set; } = string.Empty;

    public PhoneNumber PhoneNumber { get; set; } = null!;
}
