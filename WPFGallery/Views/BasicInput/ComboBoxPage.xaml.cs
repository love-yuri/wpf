using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for ComboBox.xaml
/// </summary>
public partial class ComboBoxPage : Page {
    public ComboBoxPage(ComboBoxPageViewModel viewModel) {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }

    public ComboBoxPageViewModel ViewModel { get; }
}