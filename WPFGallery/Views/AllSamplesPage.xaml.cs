using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for AllSamplesPage.xaml
/// </summary>
public partial class AllSamplesPage : Page {
    public AllSamplesPage(AllSamplesPageViewModel viewModel) {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = this;
    }

    public AllSamplesPageViewModel ViewModel { get; }
}