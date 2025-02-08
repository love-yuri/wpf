using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for PasswordBoxPage.xaml
/// </summary>
public partial class PasswordBoxPage : Page {
    public PasswordBoxPage(PasswordBoxPageViewModel viewModel) {
        ViewModel = viewModel;
        DataContext = this;
        InitializeComponent();
    }

    public PasswordBoxPageViewModel ViewModel { get; }
}