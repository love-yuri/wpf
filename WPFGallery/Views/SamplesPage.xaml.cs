using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for SamplesPage.xaml
/// </summary>
public partial class SamplesPage : Page {
    public SamplesPage(SamplesPageViewModel viewModel) {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = this;
    }

    public SamplesPageViewModel ViewModel { get; }
}