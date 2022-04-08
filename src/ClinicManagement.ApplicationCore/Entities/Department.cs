namespace ClinicManagement.ApplicationCore.Entities;

public class Department : Entity
{
    [Column(Order = 2)]
    public string Name { get; set; } = string.Empty;

    public long BranchId { get; set; }

    public virtual Branch Branch { get; set; } = new Branch();
}
