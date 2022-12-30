namespace ClinicManagement.WebApp.Components;

public partial class BootstrapAlert
{
    private bool isVisible = false;
    private string message = string.Empty;
    private string alertType = "light";

    public void Show(string message, string alertType)
    {
        isVisible = true;
        this.message = message;
        this.alertType = alertType;
        StateHasChanged();
    }

    public void Hide()
    {
        isVisible = false;
    }
}