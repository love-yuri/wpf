namespace WPFGallery.ViewModels;

public partial class RichTextEditPageViewModel : ObservableObject {
    [ObservableProperty] private string _pageDescription = "";

    [ObservableProperty] private string _pageTitle = "RichTextEdit";
}