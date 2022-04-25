namespace ClinicManagement.ApplicationCore.Entities;

public class Patient : Person
{
    public virtual ICollection<Appointment> Appointments { get; set; } = null!;
}
