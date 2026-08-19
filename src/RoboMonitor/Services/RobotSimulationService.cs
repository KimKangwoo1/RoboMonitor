using RoboMonitor.Models;

namespace RoboMonitor.Services;

public sealed class RobotSimulationService
{
    private readonly Random _random = new();
    private double _temperature = 36.0;
    private double _joint1;
    private double _joint2;
    private double _joint3;
    private double _joint4;

    public RobotTelemetry Next(bool isRunning, bool isServoOn, RobotMode mode)
    {
        var targetSpeed = isRunning && isServoOn
            ? mode == RobotMode.Auto ? _random.NextDouble() * 25 + 65 : _random.NextDouble() * 30 + 35
            : 0.0;

        var targetTemperature = isRunning
            ? 42.0 + targetSpeed * 0.28 + _random.NextDouble() * 4.0
            : 34.0 + _random.NextDouble() * 4.0;

        _temperature += (targetTemperature - _temperature) * 0.18;

        if (isRunning && isServoOn)
        {
            _joint1 = ClampJoint(_joint1 + Delta(3.5));
            _joint2 = ClampJoint(_joint2 + Delta(3.0));
            _joint3 = ClampJoint(_joint3 + Delta(2.8));
            _joint4 = ClampJoint(_joint4 + Delta(4.0));
        }

        return new RobotTelemetry(
            Math.Round(targetSpeed, 1),
            Math.Round(_temperature, 1),
            Math.Round(_joint1, 1),
            Math.Round(_joint2, 1),
            Math.Round(_joint3, 1),
            Math.Round(_joint4, 1));
    }

    private double Delta(double maxMagnitude)
        => (_random.NextDouble() * 2.0 - 1.0) * maxMagnitude;

    private static double ClampJoint(double value)
        => Math.Clamp(value, -170.0, 170.0);
}
