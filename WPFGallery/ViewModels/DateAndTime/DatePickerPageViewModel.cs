namespace WPFGallery.ViewModels;

public partial class DatePickerPageViewModel : ObservableObject {
    [ObservableProperty] private string _pageDescription = "";

    [ObservableProperty] private string _pageTitle = "DatePicker";
}