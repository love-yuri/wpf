using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for TreeViewPage.xaml
/// </summary>
public partial class TreeViewPage : Page {
    public TreeViewPage(TreeViewPageViewModel viewModel) {
        ViewModel = viewModel;
        DataContext = this;
        InitializeComponent();
    }

    public TreeViewPageViewModel ViewModel { get; }
}