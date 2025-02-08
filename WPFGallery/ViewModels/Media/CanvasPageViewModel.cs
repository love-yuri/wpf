namespace WPFGallery.ViewModels;

public partial class CanvasPageViewModel : ObservableObject {
    [ObservableProperty] private string _pageDescription = "";

    [ObservableProperty] private string _pageTitle = "Canvas";
}