namespace ClinicManagement.ApplicationCore.Entities;

public class Appointment : ScheduleItem
{
    public string? AdditionalInformation { get; set; }

    public virtual ICollection<Patient> Patients { get; set; } = null!;
}
