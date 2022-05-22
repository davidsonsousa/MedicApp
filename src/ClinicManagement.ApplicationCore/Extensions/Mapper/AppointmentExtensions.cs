namespace ClinicManagement.ApplicationCore.Extensions.Mapper;

public static class AppointmentExtensions
{
    /// <summary>
    /// Maps a Appointment entity to a AppointmentEditModel object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static AppointmentPatientRequest MapToRequest(this Appointment item)
    {
        return new AppointmentPatientRequest
        {
            VanityId = item.VanityId,
            DateTimeSchedule = item.DateTimeSchedule,
            PersonId = item.Person.VanityId
        };
    }

    /// <summary>
    /// Maps a Appointment entity to a AppointmentViewModel object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static AppointmentPatientResponse MapToResponse(this Appointment? item)
    {
        Guard.Against.Null(item, nameof(item));

        return new AppointmentPatientResponse
        {
            VanityId = item.VanityId,
            DateTimeSchedule = item.DateTimeSchedule,
            PersonId = item.Person.VanityId
        };
    }

    /// <summary>
    /// Maps IEnumerable&lt;Appointment&gt; to IEnumerable&lt;AppointmentViewModel&gt; object
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public static IEnumerable<AppointmentPatientResponse> MapToResponse(this IEnumerable<Appointment>? items)
    {
        Guard.Against.Null(items, nameof(items));

        return items.Select(appointment => new AppointmentPatientResponse
        {
            VanityId = appointment.VanityId,
            DateTimeSchedule = appointment.DateTimeSchedule,
            PersonId = appointment.Person.VanityId
        });

    }

    /// <summary>
    /// Maps a AppointmentEditModel to a Appointment entity
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static Appointment MapToEntity(this AppointmentPatientRequest item, Person? person)
    {
        Guard.Against.Null(person, nameof(person));

        return new Appointment
        {
            VanityId = item.VanityId,
            DateTimeSchedule = item.DateTimeSchedule,
            PersonId = person.Id
        };
    }

    /// <summary>
    /// Maps a AppointmentEditModel to an existing Appointment entity
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static Appointment MapToEntity(this AppointmentPatientRequest item, Appointment? appointment)
    {
        Guard.Against.Null(appointment, nameof(appointment));

        item.DateTimeSchedule = item.DateTimeSchedule;
        item.PersonId = appointment.Person.VanityId;

        return appointment;
    }
}
