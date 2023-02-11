namespace ClinicManagement.WebApp.Pages.Department;

public partial class CreateEdit
{
    [Parameter]
    public Guid? DepartmentId { get; set; }

    private string pageTitle = "New Department";
    private DepartmentEditModel departmentEditModel = new();
    private ApiResponseListModel<BranchViewModel> apiResponse = new();
    private ModalComponent? modalComponent;

    protected async override Task OnInitializedAsync()
    {
        if (DepartmentId.HasValue)
        {
            pageTitle = "Edit Department";
            var apiResponseItem = await ApiService.GetDepartmentByIdAsync<DepartmentEditModel>(DepartmentId.Value);
            departmentEditModel = apiResponseItem.Item!;
        }

        apiResponse = await ApiService.GetBranchesAsync<BranchViewModel>();
    }

    private async Task HandleValidDepartmentSubmitAsync()
    {
        try
        {
            var result = DepartmentId.HasValue ? await ApiService.UpdateDepartmentAsync(departmentEditModel) : await ApiService.InsertDepartmentAsync(departmentEditModel);
            if (!result.HasError)
            {
                departmentEditModel = new();
                modalComponent?.Show("Department", "Department saved successfully!", ModalType.OkButtonWithRedirectToUrl, redirectUrl: "/departments");
            }
            else
            {
                modalComponent?.Show("Error", "An error occurred when saving the department!", ModalType.OkButtonWithoutAction);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError("Error when saving department: {Message}", ex.Message);
        }
    }
}