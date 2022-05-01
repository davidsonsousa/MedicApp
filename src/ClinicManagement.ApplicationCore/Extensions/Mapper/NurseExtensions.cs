namespace ClinicManagement.ApplicationCore.Extensions.Mapper;

public static class NurseExtensions
{
    /// <summary>
    /// Maps a Nurse entity to a NurseRequest object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static NurseRequest MapToRequest(this Nurse item)
    {
        return new NurseRequest
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
    /// Maps a Nurse entity to a NurseResponse object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static NurseResponse MapToResponse(this Nurse? item)
    {
        Guard.Against.Null(item, nameof(item));

        return new NurseResponse
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
    /// Maps IEnumerable&lt;Nurse&gt; to IEnumerable&lt;NurseResponse&gt; object
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public static IEnumerable<NurseResponse> MapToResponse(this IEnumerable<Nurse>? items)
    {
        Guard.Against.Null(items, nameof(items));

        return items.Select(nurse => new NurseResponse
        {
            VanityId = nurse.VanityId,
            Name = nurse.Name,
            Surname = nurse.Surname,
            Address = nurse.Address,
            DateOfBirth = nurse.DateOfBirth,
            PhoneNumber = nurse.PhoneNumber
        });
    }

    /// <summary>
    /// Maps a NurseRequest to a Nurse entity
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static Nurse MapToEntity(this NurseRequest item)
    {
        return new Nurse
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
    /// Maps a NurseRequest to an existing Nurse entity
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static Nurse MapToEntity(this NurseRequest item, Nurse? nurse)
    {
        Guard.Against.Null(nurse, nameof(nurse));

        nurse.Name = item.Name;
        nurse.Surname = item.Surname;
        nurse.Address = item.Address;
        nurse.DateOfBirth = item.DateOfBirth;
        nurse.PhoneNumber = item.PhoneNumber;

        return nurse;
    }
}
