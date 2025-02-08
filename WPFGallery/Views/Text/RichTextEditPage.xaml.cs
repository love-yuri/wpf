using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for RichTextBoxPage.xaml
/// </summary>
public partial class RichTextEditPage : Page {
    public RichTextEditPage(RichTextEditPageViewModel viewModel) {
        ViewModel = viewModel;
        DataContext = this;
        InitializeComponent();
    }

    public RichTextEditPageViewModel ViewModel { get; }
}