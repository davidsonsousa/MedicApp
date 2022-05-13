namespace ClinicManagement.Infrastructure.Data.Configuration;

public class LanguageEntityConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        GeneralConfiguration.AddPropertiesForAuditing(builder);
        GeneralConfiguration.AddVanityId(builder);

        builder.HasData(GeneralConfiguration.SeedLanguages());

        // Relationships
        builder.HasMany(dept => dept.People)
               .WithMany(doc => doc.Languages)
               .UsingEntity<LanguagePerson>(b => b.HasOne<Person>().WithMany(),
                                            b => b.HasOne<Language>().WithMany())
               .HasData(GeneralConfiguration.SeedLanguagePeople());
    }
}
