namespace ClinicManagement.Infrastructure.Data.Configuration;

public class WorkScheduleEntityConfiguration : IEntityTypeConfiguration<WorkSchedule>
{
    public void Configure(EntityTypeBuilder<WorkSchedule> builder)
    {
        GeneralConfiguration.AddPropertiesForAuditing(builder);
        GeneralConfiguration.AddVanityId(builder);

        builder.OwnsOne(workSchedule => workSchedule.DateTimeSchedule);

        // Relationships
        builder.HasMany(workSchedule => workSchedule.Employees)
               .WithMany(doctor => doctor.WorkSchedules)
               .UsingEntity<WorkScheduleEmployee>(b => b.HasOne<Employee>().WithMany().OnDelete(DeleteBehavior.NoAction),
                                                  b => b.HasOne<WorkSchedule>().WithMany().OnDelete(DeleteBehavior.NoAction));
    }
}
