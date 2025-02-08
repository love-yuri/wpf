using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for CanvasPage.xaml
/// </summary>
public partial class CanvasPage : Page {
    public CanvasPage(CanvasPageViewModel viewModel) {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }

    public CanvasPageViewModel ViewModel { get; }
}