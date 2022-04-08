namespace ClinicManagement.ApplicationCore.Entities;

public abstract class ScheduleItem : Entity
{
    public DateTimeRange DateTimeSchedule { get; set; } = new DateTimeRange();

    public long PersonId { get; set; }

    public Person Person { get; set; }
}
