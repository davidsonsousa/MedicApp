namespace ClinicManagement.ApplicationCore.Extensions.Mapper;

public static class ClinicExtensions
{
    /// <summary>
    /// Maps a Clinic entity to a ClinicEditModel object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static ClinicEditModel MapToEditModel(this Clinic item)
    {
        return new ClinicEditModel
        {
            Id = item.Id,
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
    public static ClinicViewModel MapToViewModel(this Clinic? item)
    {
        Guard.Against.Null(item, nameof(item));

        return new ClinicViewModel
        {
            Id = item.Id,
            VanityId = item.VanityId,
            Name = item.Name,
            SelectedBranches = item.Branches.Select(b => b.VanityId).ToArray()
        };
    }

    /// <summary>
    /// Maps a ClinicEditModel to a Clinic entity
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static Clinic MapToEntity(this ClinicEditModel item)
    {
        return new Clinic
        {
            Id = item.Id,
            VanityId = item.VanityId,
            Name = item.Name
        };
    }

    /// <summary>
    /// Maps a ClinicEditModel to an existing Clinic entity
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static Clinic MapToEntity(this ClinicEditModel item, Clinic? clinic)
    {
        Guard.Against.Null(clinic, nameof(clinic));

        clinic.Id = item.Id;
        clinic.VanityId = item.VanityId;
        clinic.Name = item.Name;

        return clinic;
    }
}
