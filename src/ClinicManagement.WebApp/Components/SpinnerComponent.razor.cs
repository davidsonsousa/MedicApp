namespace ClinicManagement.WebApp.Components;

public partial class SpinnerComponent
{
    [Parameter]
    public bool ShowSpinner { get; set; }

    [Parameter]
    public string MessageLoading { get; set; } = "Loading...";

    [Parameter]
    public string MessageNotFound { get; set; } = "Items not found";
}