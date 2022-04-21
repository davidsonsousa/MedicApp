namespace ClinicManagement.ApplicationCore.Extensions.Mapper;

public static class ClinicExtensions
{
    /// <summary>
    /// Maps a Clinic entity to a ClinicEditModel object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static ClinicRequest MapToRequest(this Clinic item)
    {
        return new ClinicRequest
        {
            VanityId = item.VanityId,
            Name = item.Name,
            SelectedBranches = item.Branches.Select(b => b.VanityId).ToArray()
        };
    }

    /// <summary>
    /// Maps a Clinic entity to a ClinicViewModel object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static ClinicResponse MapToResponse(this Clinic? item)
    {
        Guard.Against.Null(item, nameof(item));

        return new ClinicResponse
        {
            VanityId = item.VanityId,
            Name = item.Name,
            SelectedBranches = item.Branches.Select(b => b.VanityId).ToArray()
        };
    }

    /// <summary>
    /// Maps IEnumerable&lt;Clinic&gt; to IEnumerable&lt;ClinicViewModel&gt; object
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public static IEnumerable<ClinicResponse> MapToResponse(this IEnumerable<Clinic>? items)
    {
        Guard.Against.Null(items, nameof(items));

        return items.Select(clinic => new ClinicResponse
        {
            VanityId = clinic.VanityId,
            Name = clinic.Name,
            SelectedBranches = clinic.Branches.Select(b => b.VanityId).ToArray()
        });

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
    /// <returns></returns>
    public static Clinic MapToEntity(this ClinicRequest item, Clinic? clinic)
    {
        Guard.Against.Null(clinic, nameof(clinic));

        clinic.Name = item.Name;

        return clinic;
    }
}
