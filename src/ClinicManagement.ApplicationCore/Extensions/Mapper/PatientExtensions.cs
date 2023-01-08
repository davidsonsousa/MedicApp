namespace ClinicManagement.ApplicationCore.Extensions.Mapper;

public static class PatientExtensions
{
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
            Item = new PatientDetail
            {
                VanityId = item.VanityId,
                Name = item.Name,
                Surname = item.Surname,
                Address = item.Address,
                DateOfBirth = item.DateOfBirth,
                PhoneNumber = item.PhoneNumber
            }
        };
    }

    /// <summary>
    /// Maps a Patient entity to a PatientItem object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static PatientItem MapToItem(this Patient? item)
    {
        Guard.Against.Null(item, nameof(item));

        return new PatientItem
        {
            VanityId = item.VanityId,
            Name = item.Name,
            Surname = item.Surname,
            DateOfBirth = item.DateOfBirth
        };
    }

    /// <summary>
    /// Maps IEnumerable&lt;Patient&gt; to PatientListResponse object
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public static PatientListResponse MapToListResponse(this IEnumerable<Patient>? items)
    {
        Guard.Against.Null(items, nameof(items));

        return new PatientListResponse
        {
            Items = items.Select(p => p.MapToItem())
        };
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
    /// <param name="patient"></param>
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
