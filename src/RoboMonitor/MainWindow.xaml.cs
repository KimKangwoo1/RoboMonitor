using System.Windows;
using RoboMonitor.ViewModels;

namespace RoboMonitor;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}
