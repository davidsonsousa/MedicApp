namespace ClinicManagement.Infrastructure.Data.Configuration;

public class WorkScheduleEntityConfiguration : IEntityTypeConfiguration<WorkSchedule>
{
    public void Configure(EntityTypeBuilder<WorkSchedule> builder)
    {
        GeneralConfiguration.AddPropertiesForAuditing(builder);
        GeneralConfiguration.AddVanityId(builder);

        builder.OwnsOne(workSchedule => workSchedule.DateTimeSchedule);

        builder.HasMany(workSchedule => workSchedule.Doctors)
               .WithMany(doctor => doctor.WorkSchedules)
               .UsingEntity<Dictionary<string, object>>(
                            "DoctorWorkSchedule",
                            b => b.HasOne<Doctor>()
                                  .WithMany()
                                  .OnDelete(DeleteBehavior.NoAction),
                            b => b.HasOne<WorkSchedule>()
                                  .WithMany()
                                  .OnDelete(DeleteBehavior.NoAction)
                           );

        builder.HasMany(workSchedule => workSchedule.Nurses)
               .WithMany(nurse => nurse.WorkSchedules)
               .UsingEntity<Dictionary<string, object>>(
                            "NurseWorkSchedule",
                            b => b.HasOne<Nurse>()
                                  .WithMany()
                                  .OnDelete(DeleteBehavior.NoAction),
                            b => b.HasOne<WorkSchedule>()
                                  .WithMany()
                                  .OnDelete(DeleteBehavior.NoAction)
                           );
    }
}
