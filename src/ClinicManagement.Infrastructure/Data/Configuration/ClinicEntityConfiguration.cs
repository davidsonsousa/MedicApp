namespace ClinicManagement.Infrastructure.Data.Configuration
{
    public class ClinicEntityConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            GeneralConfiguration.AddPropertiesForAuditing(builder);
            GeneralConfiguration.AddVanityId(builder);
        }
    }
}
