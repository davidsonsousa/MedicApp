namespace ClinicManagement.ApplicationCore.Extensions.Mapper;

public static class DepartmentExtensions
{
    /// <summary>
    /// Maps a Department entity to a DepartmentRequest object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static DepartmentRequest MapToRequest(this Department item)
    {
        return new DepartmentRequest
        {
            VanityId = item.VanityId,
            Name = item.Name,
            BranchId = item.Branch.VanityId
        };
    }

    /// <summary>
    /// Maps a Department entity to a DepartmentResponse object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static DepartmentResponse MapToResponse(this Department? item)
    {
        Guard.Against.Null(item, nameof(item));

        return new DepartmentResponse
        {
            VanityId = item.VanityId,
            Branch = new BranchItem
            {
                VanityId = item.Branch.VanityId,
                Name = item.Branch.Name,
                PhoneNumber = item.Branch.PhoneNumber,
                Address = item.Branch.Address
            },
            Name = item.Name,
            PhoneNumber = item.PhoneNumber
        };
    }

    /// <summary>
    /// Maps IEnumerable&lt;Department&gt; to IEnumerable&lt;DepartmentResponse&gt; object
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public static IEnumerable<DepartmentResponse> MapToResponse(this IEnumerable<Department>? items)
    {
        Guard.Against.Null(items, nameof(items));

        return items.Select(department => new DepartmentResponse
        {
            VanityId = department.VanityId,
            Branch = new BranchItem
            {
                VanityId = department.Branch.VanityId,
                Name = department.Branch.Name,
                PhoneNumber = department.Branch.PhoneNumber,
                Address = department.Branch.Address
            },
            Name = department.Name,
            PhoneNumber = department.PhoneNumber
        });
    }

    /// <summary>
    /// Maps a DepartmentRequest to a Department entity
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static Department MapToEntity(this DepartmentRequest item, Branch? branch)
    {
        Guard.Against.Null(branch, nameof(branch));

        return new Department
        {
            VanityId = item.VanityId,
            Name = item.Name,
            BranchId = branch.Id,
            PhoneNumber = item.PhoneNumber
        };
    }

    /// <summary>
    /// Maps a DepartmentRequest to an existing Department entity
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static Department MapToEntity(this DepartmentRequest item, Department? department, Branch? branch)
    {
        Guard.Against.Null(department, nameof(department));
        Guard.Against.Null(branch, nameof(branch));

        department.Name = item.Name;
        department.BranchId = branch.Id;
        department.PhoneNumber = item.PhoneNumber;

        return department;
    }
}
