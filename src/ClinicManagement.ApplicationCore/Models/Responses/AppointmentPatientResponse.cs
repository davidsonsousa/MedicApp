namespace ClinicManagement.ApplicationCore.Models.Responses;

public class AppointmentPatientResponse : ResponseBase
{
    public DateTimeRange DateTimeSchedule { get; set; } = new DateTimeRange();

    public Guid PersonId { get; set; }
}
