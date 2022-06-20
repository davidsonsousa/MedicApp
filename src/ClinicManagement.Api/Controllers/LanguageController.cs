namespace ClinicManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LanguageController : ControllerBase
{
    private readonly ILanguageService languageService;

    public LanguageController(ILanguageService languageService)
    {
        this.languageService = languageService;
    }

    /// <summary>
    /// Gets the list of languages
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of languages</returns>
    [HttpGet]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
    {
        var result = await languageService.GetAllLanguages(cancellationToken);

        if (result.HasError)
        {
            return NotFound();
        }

        var items = result.As<IEnumerable<LanguageResponse>>();

        return !items.Any() ? NotFound() : Ok(items);
    }

    /// <summary>
    /// Gets a language by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await languageService.GetLanguageById(id, cancellationToken);

        return result.HasError ? NotFound() : Ok(result.As<LanguageResponse>());
    }

    /// <summary>
    /// Inserts a new language
    /// </summary>
    /// <param name="languageRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPost]
    public async Task PostAsync(LanguageRequest languageRequest, CancellationToken cancellationToken)
    {
        await languageService.SaveAsync(languageRequest, cancellationToken);
    }

    /// <summary>
    /// Updates an existing language
    /// </summary>
    /// <param name="languageRequest"></param>
    /// <param name="cancellationToken"></param>
    [HttpPut]
    public async Task PutAsync(LanguageRequest languageRequest, CancellationToken cancellationToken)
    {
        await languageService.SaveAsync(languageRequest, cancellationToken);
    }

    /// <summary>
    /// Deletes an existing language
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await languageService.DeleteAsync(id, cancellationToken);
    }
}
