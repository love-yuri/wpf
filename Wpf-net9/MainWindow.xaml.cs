using Wpf_net9.Navigation;
using Wpf_net9.ViewModels;
using Wpf_net9.Views;

namespace Wpf_net9;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow {
    public MainWindowViewModel ViewModel { get; }
    private IServiceProvider _serviceProvider;

    public MainWindow(MainWindowViewModel viewModel, NavigationService navigationService, IServiceProvider serviceProvider) {
        ViewModel = viewModel;
        DataContext = this;
        InitializeComponent();

        _serviceProvider = serviceProvider;

        navigationService.SetFrame(RootFrame);
        navigationService.GoTo(typeof(HomePage));
    }
}
