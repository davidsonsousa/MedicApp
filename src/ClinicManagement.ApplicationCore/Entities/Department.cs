namespace ClinicManagement.ApplicationCore.Entities;

public class Department : EntityBase
{
    [Column(Order = 2)]
    public string Name { get; set; } = string.Empty;

    public long BranchId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = null!;
}
