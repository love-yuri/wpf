using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for ListBoxPage.xaml
/// </summary>
public partial class ListBoxPage : Page {
    public ListBoxPage(ListBoxPageViewModel viewModel) {
        ViewModel = viewModel;
        DataContext = this;
        InitializeComponent();
    }

    public ListBoxPageViewModel ViewModel { get; }
}