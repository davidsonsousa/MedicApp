namespace ClinicManagement.ApplicationCore.Entities;

public abstract class ScheduleItem : EntityBase
{
    [Column(Order = 11)]
    public long PersonId { get; set; }

    public Person Person { get; set; } = null!;

    public DateTimeRange DateTimeSchedule { get; set; } = new DateTimeRange();
}
