namespace ClinicManagement.ApplicationCore.Entities;

public class Language : EntityBase
{
    public virtual ICollection<Person> People { get; set; } = null!;

    [Column(Order = 20)]
    public string Name { get; set; } = string.Empty;

    [Column(Order = 21)]
    public string Code { get; set; } = string.Empty;
}
