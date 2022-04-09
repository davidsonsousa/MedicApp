namespace ClinicManagement.ApplicationCore.Entities;

public abstract class ScheduleItem : EntityBase
{
    public DateTimeRange DateTimeSchedule { get; set; } = new DateTimeRange();

    public long PersonId { get; set; }

    public Person Person { get; set; }
}
