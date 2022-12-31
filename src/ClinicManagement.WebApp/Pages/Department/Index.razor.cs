namespace ClinicManagement.WebApp.Pages.Department;

public partial class Index
{
    private IEnumerable<IGrouping<string, DepartmentViewModel>>? groupByBranch;
    private ModalComponent? modalComponent;
    private bool showSpinner;

    protected async override Task OnInitializedAsync()
    {
        showSpinner = true;
        await GetDepartmentsAsync();
        showSpinner = false;
    }

    private void ShowDeleteModal(DepartmentViewModel department)
    {
        modalComponent?.Show("Delete department?", $"Are you sure you want to delete '{department.Name}'?", ModalType.TwoButtons, department.VanityId);
    }

    private async Task GetDepartmentsAsync()
    {
        try
        {
            var departments = await ApiService.GetDepartmentsAsync<DepartmentViewModel>();
            groupByBranch = departments.GroupBy(b => b.Branch.Name);
        }
        catch (Exception ex)
        {
            Logger.LogError("Error when loading departments: {Message}", ex.Message);
        }

        StateHasChanged();
    }

    private async Task HandleEventCallbackAsync(Guid id)
    {
        try
        {
            var result = await ApiService.DeleteDepartmentAsync(id);
            if (result)
            {
                await GetDepartmentsAsync();
                modalComponent?.Show("Confirmation", "The department was successfully deleted.", ModalType.OneButtonWithoutAction);
            }
            else
            {
                modalComponent?.Show("Error", "An error occurred when deleting the department.", ModalType.OneButtonWithoutAction);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError("Error when saving department: {Message}", ex.Message);
        }
    }
}