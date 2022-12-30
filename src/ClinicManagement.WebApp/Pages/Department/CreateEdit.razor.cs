namespace ClinicManagement.WebApp.Pages.Department;

public partial class CreateEdit
{
    [Parameter]
    public Guid? DepartmentId { get; set; }

    private string pageTitle = "New Department";
    private IEnumerable<BranchViewModel> branches = new List<BranchViewModel>();
    private DepartmentEditModel departmentEditModel = new();
    private ModalComponent? modalComponent;

    protected async override Task OnInitializedAsync()
    {
        if (DepartmentId.HasValue)
        {
            pageTitle = "Edit Department";
            departmentEditModel = await ApiService.GetDepartmentByIdAsync<DepartmentEditModel>(DepartmentId.Value);
        }

        branches = await ApiService.GetBranchesAsync<BranchViewModel>();
    }

    private async Task HandleValidDepartmentSubmitAsync()
    {
        try
        {
            var result = DepartmentId.HasValue ? await ApiService.UpdateDepartmentAsync(departmentEditModel) : await ApiService.InsertDepartmentAsync(departmentEditModel);
            if (result)
            {
                departmentEditModel = new();
                modalComponent?.Show("Department", "Department saved successfully!", ModalType.OneButtonWithRedirectToUrl, redirectUrl: "/departments");
            }
            else
            {
                modalComponent?.Show("Error", "An error occurred when saving the department!", ModalType.OneButtonWithoutAction);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError("Error when saving department: {Message}", ex.Message);
        }
    }
}