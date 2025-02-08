using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for SliderPage.xaml
/// </summary>
public partial class SliderPage : Page {
    public SliderPage(SliderPageViewModel viewModel) {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }

    public SliderPageViewModel ViewModel { get; }
}