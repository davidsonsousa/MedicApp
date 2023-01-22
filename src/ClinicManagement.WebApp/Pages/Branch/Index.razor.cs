namespace ClinicManagement.WebApp.Pages.Branch;

public partial class Index
{
    private ApiResponseListModel<BranchViewModel>? apiResponse;
    private ModalComponent? modalComponent;
    private bool showSpinner;

    protected async override Task OnInitializedAsync()
    {
        showSpinner = true;
        await GetBranchesAsync();
        showSpinner = false;
    }

    private void ShowDeleteModal(BranchViewModel branch)
    {
        modalComponent?.Show("Delete branch?", $"Are you sure you want to delete '{branch.Name}'?", ModalType.TwoButtons, branch.VanityId);
    }

    private async Task GetBranchesAsync()
    {
        try
        {
            apiResponse = await ApiService.GetBranchesAsync<BranchViewModel>();
        }
        catch (Exception ex)
        {
            Logger.LogError("Error when loading branches: {Message}", ex.Message);
        }

        StateHasChanged();
    }

    private async Task HandleEventCallbackAsync(Guid id)
    {
        try
        {
            var result = await ApiService.DeleteBranchAsync(id);
            if (!result.HasError)
            {
                await GetBranchesAsync();
                modalComponent?.Show("Confirmation", "The branch was successfully deleted.", ModalType.OneButtonWithoutAction);
            }
            else
            {
                modalComponent?.Show("Error", "An error occurred when deleting the branch.", ModalType.OneButtonWithoutAction);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError("Error when saving branch: {Message}", ex.Message);
        }
    }
}