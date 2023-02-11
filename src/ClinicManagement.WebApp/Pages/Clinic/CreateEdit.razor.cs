namespace ClinicManagement.WebApp.Pages.Clinic;

public partial class CreateEdit
{
    [Parameter]
    public Guid? ClinicId { get; set; }

    private string pageTitle = "New Clinic";
    private ClinicEditModel clinicEditModel = new();
    private BranchEditModel branchEditModel = new();
    private ModalComponent? modalComponent;
    private Guid? branchId;
    private bool isEditOpen;

    protected async override Task OnInitializedAsync()
    {
        if (ClinicId.HasValue)
        {
            pageTitle = "Edit Clinic";
            var apiResponseItem = await ApiService.GetClinicByIdAsync<ClinicEditModel>(ClinicId.Value);
            clinicEditModel = apiResponseItem.Item!;
        }
    }

    private async Task HandleValidClinicSubmitAsync()
    {
        try
        {
            var result = ClinicId.HasValue ? await ApiService.UpdateClinicAsync(clinicEditModel) : await ApiService.InsertClinicAsync(clinicEditModel);
            if (!result.HasError)
            {
                clinicEditModel = new();
                modalComponent?.Show("Clinic", "Clinic saved successfully!", ModalType.OkButtonWithRedirectToUrl, redirectUrl: "/clinics");
            }
            else
            {
                modalComponent?.Show("Error", "An error occurred when saving the clinic!", ModalType.OkButtonWithoutAction);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError("Error when saving clinic: {Message}", ex.Message);
        }
    }

    private async Task HandleValidBranchSubmitAsync()
    {
        try
        {
            Guard.Against.Null(ClinicId);

            if (branchEditModel.ClinicId == Guid.Empty)
            {
                branchEditModel.ClinicId = ClinicId.Value;
            }

            var result = branchId.HasValue ? await ApiService.UpdateBranchAsync(branchEditModel) : await ApiService.InsertBranchAsync(branchEditModel);
            if (!result.HasError)
            {
                var apiResponse = await ApiService.GetBranchesByClinicIdAsync<BranchEditModel>(ClinicId.Value);
                clinicEditModel.Branches = apiResponse.Items;
                CloseEditForm();
            }
            else
            {
                modalComponent?.Show("Error", $"An error occurred when saving the branch '{branchEditModel.Name}'!", ModalType.OkButtonWithoutAction);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError("Error when saving branch: {Message}", ex.Message);
        }
    }

    private void AddBranch()
    {
        branchEditModel.ClinicId = clinicEditModel.VanityId;
        ((List<BranchEditModel>)clinicEditModel.Branches).Add(branchEditModel);
        branchId = Guid.Empty;
        isEditOpen = true;
    }

    private async Task EditBranch(Guid? vanityId)
    {
        if (vanityId.HasValue)
        {
            var apiResponseItem = await ApiService.GetBranchByIdAsync<BranchEditModel>(vanityId.Value);
            branchEditModel = apiResponseItem.Item!;
            branchId = vanityId;
            isEditOpen = true;
        }
    }

    private void CloseEditForm()
    {
        if (branchEditModel.VanityId == Guid.Empty)
        {
            ((List<BranchEditModel>)clinicEditModel.Branches).Remove(branchEditModel);
        }

        branchEditModel = new();
        branchId = null;
        isEditOpen = false;
    }
}