using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for CheckBox.xaml
/// </summary>
public partial class CheckBoxPage : Page {
    public CheckBoxPage(CheckBoxPageViewModel viewModel) {
        ViewModel = viewModel;
        DataContext = this;
        InitializeComponent();
    }

    public CheckBoxPageViewModel ViewModel { get; }
}