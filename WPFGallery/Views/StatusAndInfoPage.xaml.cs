using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for StatusAndInfoPage.xaml
/// </summary>
public partial class StatusAndInfoPage : Page {
    public StatusAndInfoPage(StatusAndInfoPageViewModel viewModel) {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = this;
    }

    public StatusAndInfoPageViewModel ViewModel { get; }
}