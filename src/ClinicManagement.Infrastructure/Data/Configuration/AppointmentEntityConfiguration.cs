namespace ClinicManagement.Infrastructure.Data.Configuration
{
    public class AppointmentEntityConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            GeneralConfiguration.AddPropertiesForAuditing(builder);
            GeneralConfiguration.AddVanityId(builder);
        }
    }
}
