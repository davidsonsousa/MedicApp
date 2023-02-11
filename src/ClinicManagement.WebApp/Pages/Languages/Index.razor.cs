namespace ClinicManagement.WebApp.Pages.Languages;

public partial class Index
{
    private ApiResponseListModel<LanguageViewModel> apiResponse = new();
    private ModalComponent? modalComponent;
    private bool showSpinner;

    protected async override Task OnInitializedAsync()
    {
        showSpinner = true;
        await GetLanguagesAsync();
        showSpinner = false;
    }

    private void ShowDeleteModal(LanguageViewModel language)
    {
        modalComponent?.Show("Delete language?", $"Are you sure you want to delete '{language.Name}'?", ModalType.TwoButtons, language.VanityId);
    }

    private async Task GetLanguagesAsync()
    {
        try
        {
            apiResponse = await ApiService.GetLanguagesAsync<LanguageViewModel>();
        }
        catch (Exception ex)
        {
            Logger.LogError("Error when loading languages: {Message}", ex.Message);
        }

        StateHasChanged();
    }

    private async Task HandleEventCallbackAsync(Guid id)
    {
        try
        {
            var result = await ApiService.DeleteLanguageAsync(id);
            if (!result.HasError)
            {
                await GetLanguagesAsync();
                modalComponent?.Show("Confirmation", "The language was successfully deleted.", ModalType.OkButtonWithoutAction);
            }
            else
            {
                modalComponent?.Show("Error", "An error occurred when deleting the language.", ModalType.OkButtonWithoutAction);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError("Error when saving language: {Message}", ex.Message);
        }
    }
}