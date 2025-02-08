using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for DateAndTimePage.xaml
/// </summary>
public partial class DateAndTimePage : Page {
    public DateAndTimePage(DateAndTimePageViewModel viewModel) {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = this;
    }

    public DateAndTimePageViewModel ViewModel { get; }
}