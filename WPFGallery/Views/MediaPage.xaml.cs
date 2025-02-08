using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for MediaPage.xaml
/// </summary>
public partial class MediaPage : Page {
    public MediaPage(MediaPageViewModel viewModel) {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = this;
    }

    public MediaPageViewModel ViewModel { get; }
}