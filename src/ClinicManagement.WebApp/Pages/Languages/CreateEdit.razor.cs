namespace ClinicManagement.WebApp.Pages.Languages;

public partial class CreateEdit
{
    [Parameter]
    public Guid? LanguageId { get; set; }

    private string pageTitle = "New Language";
    private LanguageEditModel languageEditModel = new();
    private ModalComponent? modalComponent;

    protected async override Task OnInitializedAsync()
    {
        if (LanguageId.HasValue)
        {
            pageTitle = "Edit Language";
            var apiResponseItem = await ApiService.GetLanguageByIdAsync<LanguageEditModel>(LanguageId.Value);
            languageEditModel = apiResponseItem.Item!;
        }
    }

    private async Task HandleValidLanguageSubmitAsync()
    {
        try
        {
            var result = LanguageId.HasValue ? await ApiService.UpdateLanguageAsync(languageEditModel) : await ApiService.InsertLanguageAsync(languageEditModel);
            if (!result.HasError)
            {
                languageEditModel = new();
                modalComponent?.Show("Language", "Language saved successfully!", ModalType.OkButtonWithRedirectToUrl, redirectUrl: "/languages");
            }
            else
            {
                modalComponent?.Show("Error", "An error occurred when saving the language!", ModalType.OkButtonWithoutAction);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError("Error when saving language: {Message}", ex.Message);
        }
    }
}