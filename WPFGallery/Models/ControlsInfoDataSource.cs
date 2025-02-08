using System.IO;
using System.Text.Json;

namespace WPFGallery.Models;

public class ControlInfoDataItem {
    private static readonly Assembly _assembly = typeof(ControlsInfoDataSource).Assembly;
    public string UniqueId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string IconGlyph { get; set; }
    public string ImagePath { get; set; }
    public string PageName { get; set; }
    public bool IsGroup { get; set; } = false;

    public Type PageType => _assembly.GetType($"WPFGallery.Views.{PageName}");

    public Uri ImageSource => new($"pack://application:,,,/{ImagePath}");

    public ObservableCollection<ControlInfoDataItem> Items { get; set; } = new();

    public override string ToString() {
        return Title;
    }
}

public sealed class ControlsInfoDataSource {
    private static readonly object _lock = new();

    public ICollection<ControlInfoDataItem> ControlsInfo { get; }

    private string ReadControlsData() {
        var assembly = typeof(ControlsInfoDataSource).Assembly;
        var resourceName = "WPFGallery.Models.ControlsInfoData.json";

        using (var stream = assembly.GetManifestResourceStream(resourceName))
        using (var reader = new StreamReader(stream)) {
            return reader.ReadToEnd();
        }
    }

    public ICollection<ControlInfoDataItem> GetControlsInfo(string groupName) {
        return ControlsInfo.Where(x => x.UniqueId == groupName).FirstOrDefault()?.Items;
    }

    public ICollection<ControlInfoDataItem> GetAllControlsInfo() {
        ICollection<ControlInfoDataItem> allControls = new ObservableCollection<ControlInfoDataItem>();
        foreach (var ci in ControlsInfo)
            if (ci.UniqueId != "Samples") {
                var items = ci.Items;
                foreach (var item in items) allControls.Add(item);
            }

        return allControls;
    }

    public ICollection<ControlInfoDataItem> GetGroupedControlsInfo() {
        return ControlsInfo.Where(x => x.IsGroup && x.UniqueId != "Design Guidance" && x.UniqueId != "Samples")
            .ToList();
    }

    #region Singleton

    public static ControlsInfoDataSource Instance { get; }

    static ControlsInfoDataSource() {
        Instance = new ControlsInfoDataSource();
    }

    private ControlsInfoDataSource() {
        var jsonText = ReadControlsData();
        ControlsInfo = JsonSerializer.Deserialize<List<ControlInfoDataItem>>(jsonText);
    }

    #endregion
}