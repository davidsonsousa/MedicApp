namespace ClinicManagement.ApplicationCore.Extensions.Mapper;

public static class ClinicExtensions
{
    /// <summary>
    /// Maps a Clinic entity to a ClinicDetail object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static ClinicDetail MapToResponse(this Clinic? item)
    {
        Guard.Against.Null(item, nameof(item));

        return new ClinicDetail
        {
            VanityId = item.VanityId,
            Name = item.Name,
            //Branches = item.Branches.Select(b => new BranchItem
            //{
            //    VanityId = b.VanityId,
            //    Name = b.Name,
            //    Address = b.Address,
            //    PhoneNumber = b.PhoneNumber,
            //})
        };
    }

    /// <summary>
    /// Maps a Clinic entity to a ClinicItem object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static ClinicItem MapToItem(this Clinic? item)
    {
        Guard.Against.Null(item, nameof(item));

        return new ClinicItem
        {
            VanityId = item.VanityId,
            Name = item.Name,
            BranchCount = item.Branches.Count
        };
    }

    /// <summary>
    /// Maps IEnumerable&lt;Clinic&gt; to ClinicListResponse object
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public static ClinicListResponse MapToListResponse(this IEnumerable<Clinic>? items)
    {
        Guard.Against.Null(items, nameof(items));

        return new ClinicListResponse
        {
            HasError = false,
            Items = items.Select(clinic => clinic.MapToItem())
        };
    }

    /// <summary>
    /// Maps a ClinicEditModel to a Clinic entity
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static Clinic MapToEntity(this ClinicRequest item)
    {
        return new Clinic
        {
            VanityId = item.VanityId,
            Name = item.Name
        };
    }

    /// <summary>
    /// Maps a ClinicEditModel to an existing Clinic entity
    /// </summary>
    /// <param name="item"></param>
    /// <param name="clinic"></param>
    /// <returns></returns>
    public static Clinic MapToEntity(this ClinicRequest item, Clinic? clinic)
    {
        Guard.Against.Null(clinic, nameof(clinic));

        clinic.Name = item.Name;

        return clinic;
    }
}
