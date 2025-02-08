using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for DesignGuidancePage.xaml
/// </summary>
public partial class DesignGuidancePage : Page {
    public DesignGuidancePage(DesignGuidancePageViewModel viewModel) {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = this;
    }

    public DesignGuidancePageViewModel ViewModel { get; }
}