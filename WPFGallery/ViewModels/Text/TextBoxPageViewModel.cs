namespace WPFGallery.ViewModels;

public partial class TextBoxPageViewModel : ObservableObject {
    [ObservableProperty] private string _pageDescription = "";

    [ObservableProperty] private string _pageTitle = "TextBox";
}