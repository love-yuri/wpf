namespace WPFGallery.ViewModels;

public partial class LabelPageViewModel : ObservableObject {
    [ObservableProperty] private string _pageDescription = "";

    [ObservableProperty] private string _pageTitle = "Label";
}