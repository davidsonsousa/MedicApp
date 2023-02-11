using ClinicManagement.ApplicationCore.Models.Responses.ApointmentPatient;

namespace ClinicManagement.ApplicationCore.Extensions.Mapper;

public static class AppointmentExtensions
{
    /// <summary>
    /// Maps a Appointment entity to a AppointmentPatientResponse object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static AppointmentPatientResponse MapToResponse(this Appointment? item)
    {
        Guard.Against.Null(item, nameof(item));

        return new AppointmentPatientResponse
        {
            Item = item.MapToItem()
        };
    }

    /// <summary>
    /// Maps a Appointment entity to a AppointmentPatientItem object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static AppointmentPatientItem MapToItem(this Appointment? item)
    {
        Guard.Against.Null(item, nameof(item));

        return new AppointmentPatientItem
        {
            VanityId = item.VanityId,
            DateTimeSchedule = item.DateTimeSchedule,
            PersonId = item.Person.VanityId
        };
    }

    /// <summary>
    /// Maps IEnumerable&lt;Appointment&gt; to AppointmentPatientListResponse object
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public static AppointmentPatientListResponse MapToListResponse(this IEnumerable<Appointment>? items)
    {
        Guard.Against.Null(items, nameof(items));

        return new AppointmentPatientListResponse
        {
            Items = items.Select(ap => ap.MapToItem())
        };
    }

    /// <summary>
    /// Maps a AppointmentPatientRequest to a Appointment entity
    /// </summary>
    /// <param name="item"></param>
    /// <param name="person"></param>
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
    /// Maps a AppointmentPatientRequest to an existing Appointment entity
    /// </summary>
    /// <param name="item"></param>
    /// <param name="appointment"></param>
    /// <returns></returns>
    public static Appointment MapToEntity(this AppointmentPatientRequest item, Appointment? appointment)
    {
        Guard.Against.Null(appointment, nameof(appointment));

        item.DateTimeSchedule = item.DateTimeSchedule;
        item.PersonId = appointment.Person.VanityId;

        return appointment;
    }
}
