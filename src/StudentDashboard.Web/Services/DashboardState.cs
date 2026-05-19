namespace StudentDashboard.Web.Services;

public class DashboardState
{
    public string LastMessage { get; private set; } = string.Empty;
    public event Action? OnChange;

    public void SetMessage(string message)
    {
        LastMessage = message;
        OnChange?.Invoke();
    }
}
