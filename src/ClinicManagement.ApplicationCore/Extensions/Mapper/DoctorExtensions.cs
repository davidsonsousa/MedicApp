namespace ClinicManagement.ApplicationCore.Extensions.Mapper;

public static class DoctorExtensions
{
    /// <summary>
    /// Maps a Doctor entity to a EmployeeResponse object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static EmployeeResponse MapToResponse(this Doctor? item)
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
    /// Maps a Doctor entity to a EmployeeItem object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static EmployeeItem MapToItem(this Doctor? item)
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
    /// Maps IEnumerable&lt;Doctor&gt; to EmployeeListResponse object
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public static EmployeeListResponse MapToListResponse(this IEnumerable<Doctor>? items)
    {
        Guard.Against.Null(items, nameof(items));

        return new EmployeeListResponse
        {
            Items = items.Select(e => e.MapToItem())
        };
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
    /// <param name="doctor"></param>
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
