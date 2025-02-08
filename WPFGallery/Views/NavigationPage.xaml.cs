using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for NavigationPage.xaml
/// </summary>
public partial class NavigationPage : Page {
    public NavigationPage(NavigationPageViewModel viewModel) {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = this;
    }

    public NavigationPageViewModel ViewModel { get; }
}