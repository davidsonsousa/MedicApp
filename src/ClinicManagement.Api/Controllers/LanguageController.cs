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

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var result = await languageService.GetAllLanguages(cancellationToken);

        if (result.HasError)
        {
            return NotFound();
        }

        var items = result.As<IEnumerable<LanguageResponse>>();

        return !items.Any() ? NotFound() : Ok(items);
    }

    [HttpGet("id")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var result = await languageService.GetLanguageById(id, cancellationToken);

        return result.HasError ? NotFound() : Ok(result.As<LanguageResponse>());
    }

    [HttpPost]
    public async Task PostAsync(LanguageRequest languageRequest, CancellationToken cancellationToken)
    {
        await languageService.SaveAsync(languageRequest, cancellationToken);
    }

    [HttpPut]
    public async Task PutAsync(LanguageRequest languageRequest, CancellationToken cancellationToken)
    {
        await languageService.SaveAsync(languageRequest, cancellationToken);
    }

    [HttpDelete]
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await languageService.DeleteAsync(id, cancellationToken);
    }
}
