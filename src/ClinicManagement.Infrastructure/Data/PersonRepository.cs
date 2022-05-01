namespace ClinicManagement.Infrastructure.Data;

public abstract class PersonRepository<TEntity> : RepositoryBase<Doctor>, IPersonRepository<TEntity> where TEntity : Person
{
    public PersonRepository(ClinicManagementContext dbContext, ILoggerFactory loggerFactory) : base(dbContext, loggerFactory)
    {
    }

    public async Task AddLanguagesToPersonAsync(TEntity? person, IEnumerable<Language>? languages, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(person, nameof(person));
        Guard.Against.Null(languages, nameof(languages));

        Logger.DebugMethodCall(nameof(AddLanguagesToPersonAsync));

        var languagePersonList = languages.Select(lang => new LanguagePerson
        {
            LanguageId = lang.Id,
            PersonId = person.Id
        });

        await DbContext.Set<LanguagePerson>().AddRangeAsync(languagePersonList, cancellationToken);
    }

    public async Task RemoveLanguagesFromPersonAsync(TEntity? person, IEnumerable<Language>? languages, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(person, nameof(person));
        Guard.Against.Null(languages, nameof(languages));

        Logger.DebugMethodCall(nameof(RemoveLanguagesFromPersonAsync));

        var languagePersonList = await DbContext.Set<LanguagePerson>()
                                                .Where(dd => dd.PersonId == person.Id && languages.Select(d => d.Id).Contains(dd.LanguageId))
                                                .ToListAsync(cancellationToken);

        if (languagePersonList is not null)
        {
            DbContext.RemoveRange(languagePersonList);
            await DbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task UpdatePersonLanguagesAsync(TEntity? person, IEnumerable<Language>? languages, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(person, nameof(person));

        Logger.DebugMethodCall(nameof(UpdatePersonLanguagesAsync));

        await RemoveLanguagesFromPersonAsync(person, person.Languages, cancellationToken);
        await AddLanguagesToPersonAsync(person, languages, cancellationToken);
    }
}
