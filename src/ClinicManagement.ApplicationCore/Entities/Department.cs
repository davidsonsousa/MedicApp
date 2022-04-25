namespace ClinicManagement.ApplicationCore.Entities;

public class Department : EntityBase
{
    [Column(Order = 2)]
    public string Name { get; set; } = string.Empty;

    public long BranchId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; set; } = null!;

    public virtual ICollection<Nurse> Nurses { get; set; } = null!;
}
