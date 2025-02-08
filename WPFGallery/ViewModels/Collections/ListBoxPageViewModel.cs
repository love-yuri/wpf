namespace WPFGallery.ViewModels;

public partial class ListBoxPageViewModel : ObservableObject {
    [ObservableProperty] private ObservableCollection<string> _listBoxItems;

    [ObservableProperty] private string _pageDescription = "";

    [ObservableProperty] private string _pageTitle = "ListBox";

    public ListBoxPageViewModel() {
        _listBoxItems = new ObservableCollection<string> {
            "Arial",
            "Comic Sans MS",
            "Courier New",
            "Segoe UI",
            "Times New Roman"
        };
    }
}