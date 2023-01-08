namespace ClinicManagement.ApplicationCore.Extensions.Mapper;

public static class DepartmentExtensions
{
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
            Item = item.MapToItem()
        };
    }

    /// <summary>
    /// Maps a Department entity to a DepartmentItem object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static DepartmentItem MapToItem(this Department? item)
    {
        Guard.Against.Null(item, nameof(item));

        return new DepartmentItem
        {
            VanityId = item.VanityId,
            Name = item.Name
        };
    }

    /// <summary>
    /// Maps IEnumerable&lt;Department&gt; to DepartmentListResponse object
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public static DepartmentListResponse MapToListResponse(this IEnumerable<Department>? items)
    {
        Guard.Against.Null(items, nameof(items));

        return new DepartmentListResponse
        {
            Items = items.Select(d => d.MapToItem())
        };
    }

    /// <summary>
    /// Maps a DepartmentRequest to a Department entity
    /// </summary>
    /// <param name="item"></param>
    /// <param name="branch"></param>
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
    /// <param name="department"></param>
    /// <param name="branch"></param>
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
