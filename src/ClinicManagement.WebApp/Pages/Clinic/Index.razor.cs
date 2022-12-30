namespace ClinicManagement.WebApp.Pages.Clinic;

public partial class Index
{
    private IEnumerable<ClinicViewModel>? clinics;
    private ModalComponent? modalComponent;
    private bool showSpinner;

    protected async override Task OnInitializedAsync()
    {
        showSpinner = true;
        await GetClinicsAsync();
        showSpinner = false;
    }

    private void ShowDeleteModal(ClinicViewModel clinic)
    {
        modalComponent?.Show("Delete clinic?", $"Are you sure you want to delete '{clinic.Name}'?", ModalType.TwoButtons, clinic.VanityId);
    }

    private async Task GetClinicsAsync()
    {
        try
        {
            clinics = await ApiService.GetClinicsAsync<ClinicViewModel>();
        }
        catch (Exception ex)
        {
            Logger.LogError("Error when loading clinics: {Message}", ex.Message);
        }

        StateHasChanged();
    }

    private async Task HandleEventCallbackAsync(Guid id)
    {
        try
        {
            var result = await ApiService.DeleteClinicAsync(id);
            if (result)
            {
                await GetClinicsAsync();
                modalComponent?.Show("Confirmation", "The clinic was successfully deleted.", ModalType.OneButtonWithoutAction);
            }
            else
            {
                modalComponent?.Show("Error", "An error occurred when deleting the clinic.", ModalType.OneButtonWithoutAction);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError("Error when saving clinic: {Message}", ex.Message);
        }
    }
}