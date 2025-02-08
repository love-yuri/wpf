using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for ProgressBarPage.xaml
/// </summary>
public partial class ProgressBarPage : Page {
    public ProgressBarPage(ProgressBarPageViewModel viewModel) {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }

    public ProgressBarPageViewModel ViewModel { get; }
}