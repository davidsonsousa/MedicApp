namespace ClinicManagement.Infrastructure.Data.Configuration;

public class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        GeneralConfiguration.AddPropertiesForAuditing(builder);
        GeneralConfiguration.AddVanityId(builder);

        builder.ToTable("People");

        // Date is a DateOnly property and date on database
        builder.Property(x => x.DateOfBirth)
               .HasConversion<DateOnlyConverter, DateOnlyComparer>();

        builder.OwnsOne(person => person.Address)
               .HasData(GeneralConfiguration.SeedPersonAddresses());
        builder.OwnsOne(person => person.PhoneNumber)
               .HasData(GeneralConfiguration.SeedPersonPhoneNumbers());
    }
}
