using System.Windows;
using System.Windows.Controls;
using LoveYuri.Base;
using LoveYuri.Utils;

namespace HelloWorld;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow {
    public string Text { get; set; } = "Hello World!";
    public MainWindow() {
        InitializeComponent();
        DataContext = new MainViewModel();
        TimerUtils.Timeout(2000, () => {
            Button.Content = "yuri is yes";
        }, true);
    }
}