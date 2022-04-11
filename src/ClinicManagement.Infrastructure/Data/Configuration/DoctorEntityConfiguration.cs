namespace ClinicManagement.Infrastructure.Data.Configuration
{
    public class DoctorEntityConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            GeneralConfiguration.AddPropertiesForAuditing(builder);
            GeneralConfiguration.AddVanityId(builder);
        }
    }
}
