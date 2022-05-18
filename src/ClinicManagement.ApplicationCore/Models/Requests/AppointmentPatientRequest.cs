namespace ClinicManagement.ApplicationCore.Models.Requests;

public class AppointmentPatientRequest : RequestBase
{
    public DateTimeRange DateTimeSchedule { get; set; } = new DateTimeRange();

    public Guid PersonId { get; set; }
}
