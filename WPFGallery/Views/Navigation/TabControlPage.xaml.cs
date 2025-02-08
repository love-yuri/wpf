using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for TabControlPage.xaml
/// </summary>
public partial class TabControlPage : Page {
    public TabControlPage(TabControlPageViewModel viewModel) {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }

    public TabControlPageViewModel ViewModel { get; }
}