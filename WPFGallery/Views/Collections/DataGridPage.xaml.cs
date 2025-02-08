using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for DataGridPage.xaml
/// </summary>
public partial class DataGridPage : Page {
    public DataGridPage(DataGridPageViewModel viewModel) {
        ViewModel = viewModel;
        DataContext = this;
        InitializeComponent();
    }

    public DataGridPageViewModel ViewModel { get; }
}