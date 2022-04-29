namespace ClinicManagement.Infrastructure.Data.Configuration;

public class AppointmentEntityConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        GeneralConfiguration.AddPropertiesForAuditing(builder);
        GeneralConfiguration.AddVanityId(builder);

        builder.OwnsOne(appointment => appointment.DateTimeSchedule);

        // Relationships
        builder.HasMany(appointment => appointment.Patients)
               .WithMany(patient => patient.Appointments)
               .UsingEntity<AppointmentPatient>(b => b.HasOne<Patient>().WithMany().OnDelete(DeleteBehavior.NoAction),
                                                b => b.HasOne<Appointment>().WithMany().OnDelete(DeleteBehavior.NoAction));
    }
}