
namespace ClinicManagement.ApplicationCore.Entities;

public class Clinic : Entity
{
    [Column(Order = 2)]
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();
}
