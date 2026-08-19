using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Threading;
using RoboMonitor.Commands;
using RoboMonitor.Models;
using RoboMonitor.Services;

namespace RoboMonitor.ViewModels;

public sealed class MainViewModel : ObservableObject
{
    private readonly RobotSimulationService _simulationService = new();
    private readonly DispatcherTimer _timer;

    private bool _isConnected;
    private bool _isServoOn;
    private bool _isRunning;
    private bool _isEmergencyStopped;
    private RobotMode _mode = RobotMode.Manual;
    private double _speed;
    private double _temperature = 36.0;
    private double _joint1;
    private double _joint2;
    private double _joint3;
    private double _joint4;
    private TimeSpan _operationTime;
    private bool _temperatureWarningActive;

    public MainViewModel()
    {
        ConnectCommand = new RelayCommand(_ => ToggleConnection());
        ServoCommand = new RelayCommand(_ => ToggleServo(), _ => IsConnected && !IsEmergencyStopped);
        StartCommand = new RelayCommand(_ => StartRobot(), _ => IsConnected && IsServoOn && !IsRunning && !IsEmergencyStopped);
        StopCommand = new RelayCommand(_ => StopRobot(), _ => IsRunning);
        EmergencyStopCommand = new RelayCommand(_ => EmergencyStop(), _ => IsConnected && !IsEmergencyStopped);
        ResetEmergencyCommand = new RelayCommand(_ => ResetEmergency(), _ => IsEmergencyStopped);
        ToggleModeCommand = new RelayCommand(_ => ToggleMode(), _ => IsConnected && !IsRunning && !IsEmergencyStopped);

        Logs.Add(new LogEntry(DateTime.Now, "INFO", "RoboMonitor initialized"));

        _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(500)
        };
        _timer.Tick += OnSimulationTick;
        _timer.Start();
    }

    public string ApplicationTitle => "RoboMonitor";
    public string Subtitle => "WPF Robot Control & Monitoring System";

    public ObservableCollection<AlarmEntry> Alarms { get; } = new();
    public ObservableCollection<LogEntry> Logs { get; } = new();

    public ICommand ConnectCommand { get; }
    public ICommand ServoCommand { get; }
    public ICommand StartCommand { get; }
    public ICommand StopCommand { get; }
    public ICommand EmergencyStopCommand { get; }
    public ICommand ResetEmergencyCommand { get; }
    public ICommand ToggleModeCommand { get; }

    public bool IsConnected
    {
        get => _isConnected;
        private set
        {
            if (SetProperty(ref _isConnected, value))
            {
                OnPropertyChanged(nameof(ConnectionText));
                RefreshCommands();
            }
        }
    }

    public bool IsServoOn
    {
        get => _isServoOn;
        private set
        {
            if (SetProperty(ref _isServoOn, value))
            {
                OnPropertyChanged(nameof(ServoText));
                RefreshCommands();
            }
        }
    }

    public bool IsRunning
    {
        get => _isRunning;
        private set
        {
            if (SetProperty(ref _isRunning, value))
            {
                OnPropertyChanged(nameof(RunStateText));
                RefreshCommands();
            }
        }
    }

    public bool IsEmergencyStopped
    {
        get => _isEmergencyStopped;
        private set
        {
            if (SetProperty(ref _isEmergencyStopped, value))
            {
                OnPropertyChanged(nameof(EmergencyText));
                RefreshCommands();
            }
        }
    }

    public RobotMode Mode
    {
        get => _mode;
        private set
        {
            if (SetProperty(ref _mode, value))
            {
                OnPropertyChanged(nameof(ModeText));
            }
        }
    }

    public double Speed
    {
        get => _speed;
        private set => SetProperty(ref _speed, value);
    }

    public double Temperature
    {
        get => _temperature;
        private set => SetProperty(ref _temperature, value);
    }

    public double Joint1
    {
        get => _joint1;
        private set => SetProperty(ref _joint1, value);
    }

    public double Joint2
    {
        get => _joint2;
        private set => SetProperty(ref _joint2, value);
    }

    public double Joint3
    {
        get => _joint3;
        private set => SetProperty(ref _joint3, value);
    }

    public double Joint4
    {
        get => _joint4;
        private set => SetProperty(ref _joint4, value);
    }

    public TimeSpan OperationTime
    {
        get => _operationTime;
        private set
        {
            if (SetProperty(ref _operationTime, value))
            {
                OnPropertyChanged(nameof(OperationTimeText));
            }
        }
    }

    public string ConnectionText => IsConnected ? "CONNECTED" : "DISCONNECTED";
    public string ServoText => IsServoOn ? "SERVO ON" : "SERVO OFF";
    public string RunStateText => IsRunning ? "RUNNING" : "STOPPED";
    public string EmergencyText => IsEmergencyStopped ? "E-STOP ACTIVE" : "NORMAL";
    public string ModeText => Mode.ToString().ToUpperInvariant();
    public string OperationTimeText => OperationTime.ToString(@"hh\:mm\:ss");

    private void ToggleConnection()
    {
        if (IsConnected)
        {
            IsRunning = false;
            IsServoOn = false;
            IsConnected = false;
            AddLog("INFO", "Robot disconnected");
            return;
        }

        IsConnected = true;
        AddLog("INFO", "Robot connected");
    }

    private void ToggleServo()
    {
        IsServoOn = !IsServoOn;
        if (!IsServoOn)
        {
            IsRunning = false;
        }

        AddLog("INFO", IsServoOn ? "Servo turned ON" : "Servo turned OFF");
    }

    private void StartRobot()
    {
        IsRunning = true;
        AddLog("INFO", $"Robot started in {ModeText} mode");
    }

    private void StopRobot()
    {
        IsRunning = false;
        AddLog("INFO", "Robot stopped");
    }

    private void EmergencyStop()
    {
        IsRunning = false;
        IsServoOn = false;
        IsEmergencyStopped = true;
        AddAlarm("ERROR", "Emergency stop activated");
        AddLog("ERROR", "Emergency stop activated");
    }

    private void ResetEmergency()
    {
        IsEmergencyStopped = false;
        AddLog("INFO", "Emergency stop reset");
    }

    private void ToggleMode()
    {
        Mode = Mode == RobotMode.Manual ? RobotMode.Auto : RobotMode.Manual;
        AddLog("INFO", $"Mode changed to {ModeText}");
    }

    private void OnSimulationTick(object? sender, EventArgs e)
    {
        if (IsRunning)
        {
            OperationTime += _timer.Interval;
        }

        var telemetry = _simulationService.Next(IsRunning, IsServoOn, Mode);
        Speed = telemetry.Speed;
        Temperature = telemetry.Temperature;
        Joint1 = telemetry.Joint1;
        Joint2 = telemetry.Joint2;
        Joint3 = telemetry.Joint3;
        Joint4 = telemetry.Joint4;

        HandleTemperatureAlarm();
    }

    private void HandleTemperatureAlarm()
    {
        if (Temperature >= 60.0 && !_temperatureWarningActive)
        {
            _temperatureWarningActive = true;
            AddAlarm("WARNING", $"Motor temperature high: {Temperature:F1} °C");
            AddLog("WARNING", "High motor temperature detected");
        }
        else if (Temperature < 55.0 && _temperatureWarningActive)
        {
            _temperatureWarningActive = false;
            AddLog("INFO", "Motor temperature returned to normal");
        }
    }

    private void AddAlarm(string level, string message)
    {
        Alarms.Insert(0, new AlarmEntry(DateTime.Now, level, message));
    }

    private void AddLog(string level, string message)
    {
        Logs.Insert(0, new LogEntry(DateTime.Now, level, message));

        if (Logs.Count > 100)
        {
            Logs.RemoveAt(Logs.Count - 1);
        }
    }

    private static void RefreshCommands()
    {
        CommandManager.InvalidateRequerySuggested();
    }
}
