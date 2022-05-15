namespace ClinicManagement.ApplicationCore.Entities;

public class Appointment : ScheduleItem
{
    [Column(Order = 21)]
    public string? AdditionalInformation { get; set; }
}
