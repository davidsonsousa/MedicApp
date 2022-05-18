namespace ClinicManagement.ApplicationCore.Extensions.Mapper;

public static class PatientExtensions
{
    /// <summary>
    /// Maps a Patient entity to a PatientRequest object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static PatientRequest MapToRequest(this Patient item)
    {
        return new PatientRequest
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
    /// Maps a Patient entity to a PatientResponse object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static PatientResponse MapToResponse(this Patient? item)
    {
        Guard.Against.Null(item, nameof(item));

        return new PatientResponse
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
    /// Maps IEnumerable&lt;Patient&gt; to IEnumerable&lt;PatientResponse&gt; object
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public static IEnumerable<PatientResponse> MapToResponse(this IEnumerable<Patient>? items)
    {
        Guard.Against.Null(items, nameof(items));

        return items.Select(patient => new PatientResponse
        {
            VanityId = patient.VanityId,
            Name = patient.Name,
            Surname = patient.Surname,
            Address = patient.Address,
            DateOfBirth = patient.DateOfBirth,
            PhoneNumber = patient.PhoneNumber
        });
    }

    /// <summary>
    /// Maps a PatientRequest to a Patient entity
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static Patient MapToEntity(this PatientRequest item)
    {
        return new Patient
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
    /// Maps a PatientRequest to an existing Patient entity
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static Patient MapToEntity(this PatientRequest item, Patient? patient)
    {
        Guard.Against.Null(patient, nameof(patient));

        patient.Name = item.Name;
        patient.Surname = item.Surname;
        patient.Address = item.Address;
        patient.DateOfBirth = item.DateOfBirth;
        patient.PhoneNumber = item.PhoneNumber;

        return patient;
    }
}
