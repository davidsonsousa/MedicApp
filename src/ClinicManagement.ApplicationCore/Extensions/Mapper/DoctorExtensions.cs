namespace ClinicManagement.ApplicationCore.Extensions.Mapper;

public static class DoctorExtensions
{
    /// <summary>
    /// Maps a Doctor entity to a DoctorRequest object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static DoctorRequest MapToRequest(this Doctor item)
    {
        return new DoctorRequest
        {
            VanityId = item.VanityId,
            Name = item.Name,
            Surname = item.Surname,
            Address = item.Address,
            DateOfBirth = item.DateOfBirth,
            PhoneNumber = item.PhoneNumber
        };
    }

    /// <summary>
    /// Maps a Doctor entity to a DoctorResponse object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static DoctorResponse MapToResponse(this Doctor? item)
    {
        Guard.Against.Null(item, nameof(item));

        return new DoctorResponse
        {
            VanityId = item.VanityId,
            Name = item.Name,
            Surname = item.Surname,
            Address = item.Address,
            DateOfBirth = item.DateOfBirth,
            PhoneNumber = item.PhoneNumber
        };
    }

    /// <summary>
    /// Maps IEnumerable&lt;Doctor&gt; to IEnumerable&lt;DoctorResponse&gt; object
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public static IEnumerable<DoctorResponse> MapToResponse(this IEnumerable<Doctor>? items)
    {
        Guard.Against.Null(items, nameof(items));

        return items.Select(doctor => new DoctorResponse
        {
            VanityId = doctor.VanityId,
            Name = doctor.Name,
            Surname = doctor.Surname,
            Address = doctor.Address,
            DateOfBirth = doctor.DateOfBirth,
            PhoneNumber = doctor.PhoneNumber
        });
    }

    /// <summary>
    /// Maps a DoctorRequest to a Doctor entity
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static Doctor MapToEntity(this DoctorRequest item)
    {
        return new Doctor
        {
            VanityId = item.VanityId,
            Name = item.Name,
            Surname = item.Surname,
            Address = item.Address,
            DateOfBirth = item.DateOfBirth,
            PhoneNumber = item.PhoneNumber
        };
    }

    /// <summary>
    /// Maps a DoctorRequest to an existing Doctor entity
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static Doctor MapToEntity(this DoctorRequest item, Doctor? doctor)
    {
        Guard.Against.Null(doctor, nameof(doctor));

        doctor.Name = item.Name;
        doctor.Surname = item.Surname;
        doctor.Address = item.Address;
        doctor.DateOfBirth = item.DateOfBirth;
        doctor.PhoneNumber = item.PhoneNumber;

        return doctor;
    }
}
