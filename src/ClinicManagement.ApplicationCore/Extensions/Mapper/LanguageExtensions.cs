namespace ClinicManagement.ApplicationCore.Extensions.Mapper;

public static class LanguageExtensions
{
    /// <summary>
    /// Maps a Language entity to a LanguageRequest object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static LanguageRequest MapToRequest(this Language item)
    {
        return new LanguageRequest
        {
            VanityId = item.VanityId,
            Name = item.Name,
            Code = item.Code
        };
    }

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
            VanityId = item.VanityId,
            Name = item.Name,
            Code = item.Code
        };
    }

    /// <summary>
    /// Maps IEnumerable&lt;Language&gt; to IEnumerable&lt;LanguageResponse&gt; object
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public static IEnumerable<LanguageResponse> MapToResponse(this IEnumerable<Language>? items)
    {
        Guard.Against.Null(items, nameof(items));

        return items.Select(language => new LanguageResponse
        {
            VanityId = language.VanityId,
            Name = language.Name,
            Code = language.Code
        });
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
    /// <returns></returns>
    public static Language MapToEntity(this LanguageRequest item, Language? language)
    {
        Guard.Against.Null(language, nameof(language));

        language.Name = item.Name;
        language.Code = item.Code;

        return language;
    }
}
