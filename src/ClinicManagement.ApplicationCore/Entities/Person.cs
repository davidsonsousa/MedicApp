namespace ClinicManagement.ApplicationCore.Entities;

public abstract class Person : EntityBase
{
    [Column(Order = 2)]
    public string Name { get; set; } = string.Empty;

    [Column(Order = 3)]
    public string Surname { get; set; } = string.Empty;

    [Column(Order = 4)]
    public DateOnly DateOfBirth { get; set; }

    public Address Address { get; set; } = new Address();

    public PhoneNumber PhoneNumber { get; set; } = new PhoneNumber();

    public virtual ICollection<Language> Languages { get; set; } = null!;
}
