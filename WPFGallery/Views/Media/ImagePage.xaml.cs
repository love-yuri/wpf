using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for ImagePage.xaml
/// </summary>
public partial class ImagePage : Page {
    public ImagePage(ImagePageViewModel viewModel) {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }

    public ImagePageViewModel ViewModel { get; }
}