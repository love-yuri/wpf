using Wpf_net9.ViewModels;

namespace Wpf_net9;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow {
    public MainWindowViewModel ViewModel { get; }
    public MainWindow(MainWindowViewModel viewModel) {
        ViewModel = viewModel;
        DataContext = this;
        InitializeComponent();
    }
}