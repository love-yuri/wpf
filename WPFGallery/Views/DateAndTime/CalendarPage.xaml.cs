using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for CalendarPage.xaml
/// </summary>
public partial class CalendarPage : Page {
    public CalendarPage(CalendarPageViewModel viewModel) {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }

    public CalendarPageViewModel ViewModel { get; }
}