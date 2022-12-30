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
            clinicEditModel = await ApiService.GetClinicByIdAsync<ClinicEditModel>(ClinicId.Value);
        }
    }

    private async Task HandleValidClinicSubmitAsync()
    {
        try
        {
            var result = ClinicId.HasValue ? await ApiService.UpdateClinicAsync(clinicEditModel) : await ApiService.InsertClinicAsync(clinicEditModel);
            if (result)
            {
                clinicEditModel = new();
                modalComponent?.Show("Clinic", "Clinic saved successfully!", ModalType.OneButtonWithRedirectToUrl, redirectUrl: "/clinics");
            }
            else
            {
                modalComponent?.Show("Error", "An error occurred when saving the clinic!", ModalType.OneButtonWithoutAction);
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
            if (branchEditModel.ClinicId == Guid.Empty)
            {
                branchEditModel.ClinicId = ClinicId.Value;
            }

            var result = branchId.HasValue ? await ApiService.UpdateBranchAsync(branchEditModel) : await ApiService.InsertBranchAsync(branchEditModel);
            if (result)
            {
                clinicEditModel.Branches = await ApiService.GetBranchesByClinicIdAsync<BranchEditModel>(ClinicId.Value);
                CloseEditForm();
            }
            else
            {
                modalComponent?.Show("Error", $"An error occurred when saving the branch '{branchEditModel.Name}'!", ModalType.OneButtonWithoutAction);
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
            branchEditModel = await ApiService.GetBranchByIdAsync<BranchEditModel>(vanityId.Value);
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