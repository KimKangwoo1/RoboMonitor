namespace RoboMonitor.Models;

public sealed record AlarmEntry(DateTime Timestamp, string Level, string Message)
{
    public string Time => Timestamp.ToString("HH:mm:ss");
}
