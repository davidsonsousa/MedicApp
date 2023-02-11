namespace ClinicManagement.WebApp.Pages.Branch;

public partial class CreateEdit
{
    [Parameter]
    public Guid? BranchId { get; set; }

    private string pageTitle = "New Branch";
    private ApiResponseListModel<ClinicViewModel> apiResponseList = new();
    private BranchEditModel branchEditModel = new();
    private DepartmentEditModel departmentEditModel = new();
    private ModalComponent? modalComponent;
    private Guid? departmentId;
    private bool isEditOpen;

    protected async override Task OnInitializedAsync()
    {
        if (BranchId.HasValue)
        {
            pageTitle = "Edit Branch";
            var apiResponseItem = await ApiService.GetBranchByIdAsync<BranchEditModel>(BranchId.Value);
            branchEditModel = apiResponseItem.Item!;
        }

        apiResponseList = await ApiService.GetClinicsAsync<ClinicViewModel>();
    }

    private async Task HandleValidBranchSubmitAsync()
    {
        try
        {
            var result = BranchId.HasValue ? await ApiService.UpdateBranchAsync(branchEditModel) : await ApiService.InsertBranchAsync(branchEditModel);
            if (!result.HasError)
            {
                branchEditModel = new();
                modalComponent?.Show("Branch", "Branch saved successfully!", ModalType.OneButtonWithRedirectToUrl, redirectUrl: "/branches");
            }
            else
            {
                modalComponent?.Show("Error", "An error occurred when saving the branch!", ModalType.OneButtonWithoutAction);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError("Error when saving branch: {Message}", ex.Message);
        }
    }

    private async Task HandleValidDepartmentSubmitAsync()
    {
        try
        {
            Guard.Against.Null(BranchId);

            if (departmentEditModel.BranchId == Guid.Empty)
            {
                departmentEditModel.BranchId = BranchId.Value;
            }

            var result = departmentId.HasValue ? await ApiService.UpdateDepartmentAsync(departmentEditModel) : await ApiService.InsertDepartmentAsync(departmentEditModel);
            if (!result.HasError)
            {
                var apiResponse = await ApiService.GetDepartmentsByBranchIdAsync<DepartmentEditModel>(BranchId.Value);
                branchEditModel.Departments = apiResponse.Items;
                CloseEditForm();
            }
            else
            {
                modalComponent?.Show("Error", $"An error occurred when saving the department '{departmentEditModel.Name}'!", ModalType.OneButtonWithoutAction);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError("Error when saving department: {Message}", ex.Message);
        }
    }

    private void AddDepartment()
    {
        departmentEditModel.BranchId = branchEditModel.VanityId;
        ((List<DepartmentEditModel>)branchEditModel.Departments).Add(departmentEditModel);
        departmentId = Guid.Empty;
        isEditOpen = true;
    }

    private async Task EditDepartment(Guid? vanityId)
    {
        if (vanityId.HasValue)
        {
            var apiResponseItem = await ApiService.GetDepartmentByIdAsync<DepartmentEditModel>(vanityId.Value);
            departmentEditModel = apiResponseItem.Item!;
            departmentId = vanityId;
            isEditOpen = true;
        }
    }

    private void CloseEditForm()
    {
        if (departmentEditModel.VanityId == Guid.Empty)
        {
            ((List<DepartmentEditModel>)branchEditModel.Departments).Remove(departmentEditModel);
        }

        departmentEditModel = new();
        departmentId = null;
        isEditOpen = false;
    }
}