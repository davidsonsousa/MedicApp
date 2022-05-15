namespace ClinicManagement.Infrastructure.Data.Configuration;

public class WorkScheduleEntityConfiguration : IEntityTypeConfiguration<WorkSchedule>
{
    public void Configure(EntityTypeBuilder<WorkSchedule> builder)
    {
        GeneralConfiguration.AddPropertiesForAuditing(builder);
        GeneralConfiguration.AddVanityId(builder);

        builder.OwnsOne(workSchedule => workSchedule.DateTimeSchedule);
    }
}
