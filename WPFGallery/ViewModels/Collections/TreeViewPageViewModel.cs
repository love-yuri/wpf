namespace WPFGallery.ViewModels;

public partial class TreeViewPageViewModel : ObservableObject {
    [ObservableProperty] private string _pageDescription = "";

    [ObservableProperty] private string _pageTitle = "TreeView";
}