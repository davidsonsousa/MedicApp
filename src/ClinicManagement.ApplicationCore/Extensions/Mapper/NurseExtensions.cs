namespace ClinicManagement.ApplicationCore.Extensions.Mapper;

public static class NurseExtensions
{
    /// <summary>
    /// Maps a Nurse entity to a EmployeeResponse object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static EmployeeResponse MapToResponse(this Nurse? item)
    {
        Guard.Against.Null(item, nameof(item));

        return new EmployeeResponse
        {
            Item = new EmployeeDetail
            {
                VanityId = item.VanityId,
                Name = item.Name,
                Surname = item.Surname,
                Address = item.Address,
                DateOfBirth = item.DateOfBirth,
                PhoneNumber = item.PhoneNumber,
                Departments = item.Departments.Select(d => d.MapToItem()),
                Languages = item.Languages.Select(l => l.MapToItem())
            }
        };
    }

    /// <summary>
    /// Maps a Nurse entity to a EmployeeItem object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static EmployeeItem MapToItem(this Nurse? item)
    {
        Guard.Against.Null(item, nameof(item));

        return new EmployeeItem
        {
            VanityId = item.VanityId,
            Name = item.Name,
            Surname = item.Surname,
            DateOfBirth = item.DateOfBirth
        };
    }

    /// <summary>
    /// Maps IEnumerable&lt;Nurse&gt; to EmployeeListResponse object
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public static EmployeeListResponse MapToListResponse(this IEnumerable<Nurse>? items)
    {
        Guard.Against.Null(items, nameof(items));

        return new EmployeeListResponse
        {
            Items = items.Select(e => e.MapToItem())
        };
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
    /// <param name="nurse"></param>
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
