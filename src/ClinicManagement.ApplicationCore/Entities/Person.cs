namespace ClinicManagement.ApplicationCore.Entities;

public abstract class Person : EntityBase
{
    public virtual ICollection<Language> Languages { get; set; } = null!;

    [Column(Order = 20)]
    public string Name { get; set; } = string.Empty;

    [Column(Order = 21)]
    public string Surname { get; set; } = string.Empty;

    [Column(Order = 22)]
    public DateOnly DateOfBirth { get; set; }

    public Address Address { get; set; } = new Address();

    public PhoneNumber PhoneNumber { get; set; } = new PhoneNumber();
}
