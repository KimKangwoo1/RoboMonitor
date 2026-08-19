namespace RoboMonitor.ViewModels;

public sealed class MainViewModel : ObservableObject
{
    private string _statusMessage = "MVVM binding is connected";

    public string ApplicationTitle => "RoboMonitor";

    public string Subtitle => "WPF Robot Control & Monitoring System";

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }
}
