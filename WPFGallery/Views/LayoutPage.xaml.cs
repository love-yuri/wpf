using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for LayoutPage.xaml
/// </summary>
public partial class LayoutPage : Page {
    public LayoutPage(LayoutPageViewModel viewModel) {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = this;
    }

    public LayoutPageViewModel ViewModel { get; }
}