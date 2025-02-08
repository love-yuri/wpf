using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for CollectionsPage.xaml
/// </summary>
public partial class CollectionsPage : Page {
    public CollectionsPage(CollectionsPageViewModel viewModel) {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = this;
    }

    public CollectionsPageViewModel ViewModel { get; }
}