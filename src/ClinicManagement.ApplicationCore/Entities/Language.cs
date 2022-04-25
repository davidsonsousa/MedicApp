namespace ClinicManagement.ApplicationCore.Entities;

public class Language : EntityBase
{
    [Column(Order = 2)]
    public string Name { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public virtual ICollection<Person> People { get; set; } = null!;
}
