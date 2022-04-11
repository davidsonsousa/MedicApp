namespace ClinicManagement.Infrastructure.Data.Configuration
{
    public class PatientEntityConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            GeneralConfiguration.AddPropertiesForAuditing(builder);
            GeneralConfiguration.AddVanityId(builder);
        }
    }
}
