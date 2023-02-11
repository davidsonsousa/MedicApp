namespace ClinicManagement.ApplicationCore.Extensions.Mapper;

public static class LanguageExtensions
{
    /// <summary>
    /// Maps a Language entity to a LanguageResponse object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static LanguageResponse MapToResponse(this Language? item)
    {
        Guard.Against.Null(item, nameof(item));

        return new LanguageResponse
        {
            Item = new LanguageItem
            {
                VanityId = item.VanityId,
                Name = item.Name,
                Code = item.Code
            }
        };
    }

    /// <summary>
    /// Maps a Language entity to a LanguageItem object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static LanguageItem MapToItem(this Language? item)
    {
        Guard.Against.Null(item, nameof(item));

        return new LanguageItem
        {
            VanityId = item.VanityId,
            Name = item.Name,
            Code = item.Code
        };
    }

    /// <summary>
    /// Maps IEnumerable&lt;Language&gt; to LanguageListResponse object
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public static LanguageListResponse MapToListResponse(this IEnumerable<Language>? items)
    {
        Guard.Against.Null(items, nameof(items));

        return new LanguageListResponse
        {
            Items = items.Select(l => l.MapToItem())
        };
    }

    /// <summary>
    /// Maps a LanguageRequest to a Language entity
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static Language MapToEntity(this LanguageRequest item)
    {
        return new Language
        {
            VanityId = item.VanityId,
            Name = item.Name,
            Code = item.Code
        };
    }

    /// <summary>
    /// Maps a LanguageRequest to an existing Language entity
    /// </summary>
    /// <param name="item"></param>
    /// <param name="language"></param>
    /// <returns></returns>
    public static Language MapToEntity(this LanguageRequest item, Language? language)
    {
        Guard.Against.Null(language, nameof(language));

        language.Name = item.Name;
        language.Code = item.Code;

        return language;
    }
}
