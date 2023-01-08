namespace ClinicManagement.ApplicationCore.Extensions.Mapper;

public static class BranchExtensions
{
    /// <summary>
    /// Maps a Branch entity to a BranchResponse object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static BranchResponse MapToResponse(this Branch? item)
    {
        Guard.Against.Null(item, nameof(item));

        return new BranchResponse
        {
            HasError = false,
            Item = new BranchDetail
            {
                VanityId = item.VanityId,
                ClinicId = item.Clinic.VanityId,
                Name = item.Name,
                Address = item.Address,
                PhoneNumber = item.PhoneNumber,
                //Departments = item.Departments.Select(d => new DepartmentResponse
                //{
                //    VanityId = d.VanityId,
                //    Name = d.Name,
                //    PhoneNumber = d.PhoneNumber
                //})
            }
        };
    }

    /// <summary>
    /// Maps a Branch entity to a BranchItem object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static BranchItem MapToItem(this Branch? item)
    {
        Guard.Against.Null(item, nameof(item));

        return new BranchItem
        {
            VanityId = item.VanityId,
            Name = item.Name,
            DepartmentCount = item.Departments.Count
        };
    }

    /// <summary>
    /// Maps IEnumerable&lt;Branch&gt; to BranchListResponse object
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public static BranchListResponse MapToListResponse(this IEnumerable<Branch>? items)
    {
        Guard.Against.Null(items, nameof(items));

        return new BranchListResponse
        {
            HasError = false,
            Items = items.Select(b => b.MapToItem())
        };
    }

    /// <summary>
    /// Maps a BranchRequest to a Branch entity
    /// </summary>
    /// <param name="item"></param>
    /// <param name="clinic"></param>
    /// <returns></returns>
    public static Branch MapToEntity(this BranchRequest item, Clinic? clinic)
    {
        Guard.Against.Null(clinic, nameof(clinic));

        return new Branch
        {
            VanityId = item.VanityId,
            Name = item.Name,
            Address = item.Address,
            PhoneNumber = item.PhoneNumber,
            ClinicId = clinic.Id,
        };
    }

    /// <summary>
    /// Maps a BranchRequest to an existing Branch entity
    /// </summary>
    /// <param name="item"></param>
    /// <param name="branch"></param>
    /// <param name="clinic"></param>
    /// <returns></returns>
    public static Branch MapToEntity(this BranchRequest item, Branch? branch, Clinic? clinic)
    {
        Guard.Against.Null(branch, nameof(branch));
        Guard.Against.Null(clinic, nameof(clinic));

        branch.Name = item.Name;
        branch.Address = item.Address;
        branch.PhoneNumber = item.PhoneNumber;
        branch.ClinicId = clinic.Id;

        return branch;
    }
}
