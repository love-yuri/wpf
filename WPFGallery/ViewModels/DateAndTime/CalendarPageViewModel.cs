namespace WPFGallery.ViewModels;

public partial class CalendarPageViewModel : ObservableObject {
    [ObservableProperty] private string _pageDescription = "";

    [ObservableProperty] private string _pageTitle = "Calendar";
}