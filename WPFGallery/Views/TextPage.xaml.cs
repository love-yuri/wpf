using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for TextPage.xaml
/// </summary>
public partial class TextPage : Page {
    public TextPage(TextPageViewModel viewModel) {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = this;
    }

    public TextPageViewModel ViewModel { get; }
}