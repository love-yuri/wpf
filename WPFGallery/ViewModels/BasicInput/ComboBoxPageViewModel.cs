namespace WPFGallery.ViewModels;

public partial class ComboBoxPageViewModel : ObservableObject {
    [ObservableProperty] private IList<string> _comboBoxFontFamilies = new ObservableCollection<string> {
        "Arial",
        "Comic Sans MS",
        "Segoe UI",
        "Times New Roman"
    };

    [ObservableProperty] private IList<int> _comboBoxFontSizes = new ObservableCollection<int> {
        8,
        9,
        10,
        11,
        12,
        14,
        16,
        18,
        20,
        24,
        28,
        36,
        48,
        72
    };

    [ObservableProperty] private string _pageDescription = "";

    [ObservableProperty] private string _pageTitle = "ComboBox";
}