using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for ListViewPage.xaml
/// </summary>
public partial class ListViewPage : Page {
    public ListViewPage(ListViewPageViewModel viewModel) {
        ViewModel = viewModel;
        DataContext = this;
        InitializeComponent();
    }

    public ListViewPageViewModel ViewModel { get; }
}