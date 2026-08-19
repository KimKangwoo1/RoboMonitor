namespace RoboMonitor.Models;

public enum RobotMode
{
    Manual,
    Auto
}

public sealed record RobotTelemetry(
    double Speed,
    double Temperature,
    double Joint1,
    double Joint2,
    double Joint3,
    double Joint4);
