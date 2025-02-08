namespace WPFGallery.ViewModels;

public partial class TextBlockPageViewModel : ObservableObject {
    [ObservableProperty] private string _pageDescription = "";

    [ObservableProperty] private string _pageTitle = "TextBlock";
}