using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for Button.xaml
/// </summary>
public partial class ButtonPage : Page {
    public ButtonPage(ButtonPageViewModel viewModel) {
        ViewModel = viewModel;
        DataContext = this;
        InitializeComponent();
    }

    public ButtonPageViewModel ViewModel { get; }
}