namespace ClinicManagement.ApplicationCore.Entities;

public class Clinic : EntityBase
{
    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    [Column(Order = 20)]
    public string Name { get; set; } = string.Empty;
}
