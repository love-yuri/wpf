using System.IO;
using System.Text.Json;
using WPFGallery.Models;

namespace WPFGallery.ViewModels;

public partial class IconsPageViewModel : ObservableObject {
    [ObservableProperty] private ICollection<IconData> _icons;

    [ObservableProperty] private string _pageDescription = "Guide showing how to use icons in your application.";

    [ObservableProperty] private string _pageTitle = "Icons";

    [ObservableProperty] private IconData? _selectedIcon;

    public IconsPageViewModel() {
        var jsonText = ReadIconData();
        _icons = JsonSerializer.Deserialize<List<IconData>>(jsonText);
        _selectedIcon = _icons.FirstOrDefault();
    }

    private string ReadIconData() {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = "WPFGallery.Models.IconsData.json";

        using (var stream = assembly.GetManifestResourceStream(resourceName))
        using (var reader = new StreamReader(stream)) {
            return reader.ReadToEnd();
        }
    }
}