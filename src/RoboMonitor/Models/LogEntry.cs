namespace RoboMonitor.Models;

public sealed record LogEntry(DateTime Timestamp, string Level, string Message)
{
    public string Time => Timestamp.ToString("HH:mm:ss");
}
