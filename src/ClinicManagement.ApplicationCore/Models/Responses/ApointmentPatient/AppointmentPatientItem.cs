namespace ClinicManagement.ApplicationCore.Models.Responses.ApointmentPatient;

public class AppointmentPatientItem
{
    public Guid VanityId { get; set; }

    public DateTimeRange DateTimeSchedule { get; set; } = new DateTimeRange();

    public Guid PersonId { get; set; }
}