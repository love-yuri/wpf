namespace WPFGallery.ViewModels;

public partial class TypographyPageViewModel : ObservableObject {
    [ObservableProperty] private string _pageDescription = "Guide showing how to use typography in your app";

    [ObservableProperty] private string _pageTitle = "Typography";
}