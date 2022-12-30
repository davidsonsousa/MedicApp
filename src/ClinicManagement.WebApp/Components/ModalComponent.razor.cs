using Ardalis.GuardClauses;

namespace ClinicManagement.WebApp.Components;

public partial class ModalComponent
{
    [Parameter]
    public EventCallback<Guid> EventCallback { get; set; }

    [Parameter]
    public string PrimaryButtonText { get; set; } = "Ok";

    [Parameter]
    public string SecondaryButtonText { get; set; } = "Cancel";

    private bool isVisible = false;
    private string title = "Modal";
    private string content = string.Empty;
    private ModalType modalType;
    public Guid? id;
    public string redirectUrl = "/";

    public void Show(string title, string content, ModalType modalType, Guid? id = null, string redirectUrl = "/")
    {
        isVisible = true;
        this.title = title;
        this.content = content;
        this.modalType = modalType;
        this.id = id;
        this.redirectUrl = redirectUrl;
        StateHasChanged();
    }

    public void Hide()
    {
        isVisible = false;
    }

    public void RedirectToUrl()
    {
        if (!string.IsNullOrWhiteSpace(redirectUrl))
        {
            NavigationManager.NavigateTo(redirectUrl);
        }
    }

    private async Task ExecuteActionAsync()
    {
        Guard.Against.Null(id);
        Hide();
        await EventCallback.InvokeAsync(id.Value);
    }
}