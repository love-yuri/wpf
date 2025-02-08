using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for LabelPage.xaml
/// </summary>
public partial class LabelPage : Page {
    public LabelPage(LabelPageViewModel viewModel) {
        ViewModel = viewModel;
        DataContext = this;
        InitializeComponent();
    }

    public LabelPageViewModel ViewModel { get; }
}