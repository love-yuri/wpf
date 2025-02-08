using WPFGallery.Models;

namespace WPFGallery.ViewModels;

public partial class ListViewPageViewModel : ObservableObject {
    [ObservableProperty] private ObservableCollection<Person> _basicListViewItems;

    [ObservableProperty] private SelectionMode _listViewSelectionMode = SelectionMode.Single;

    private int _listViewSelectionModeComboBoxSelectedIndex;

    [ObservableProperty] private string _pageDescription = "";

    [ObservableProperty] private string _pageTitle = "ListView";

    public ListViewPageViewModel() {
        _basicListViewItems = GeneratePersons();
    }

    public int ListViewSelectionModeComboBoxSelectedIndex {
        get => _listViewSelectionModeComboBoxSelectedIndex;
        set {
            SetProperty(ref _listViewSelectionModeComboBoxSelectedIndex, value);
            UpdateListViewSelectionMode(value);
        }
    }

    private ObservableCollection<Person> GeneratePersons() {
        var random = new Random();
        var persons = new ObservableCollection<Person>();

        var names = new[] {
            "John",
            "Winston",
            "Adrianna",
            "Spencer",
            "Phoebe",
            "Lucas",
            "Carl",
            "Marissa",
            "Brandon",
            "Antoine",
            "Arielle",
            "Arielle",
            "Jamie",
            "Alexander"
        };
        var surnames = new[] {
            "Doe",
            "Tapia",
            "Cisneros",
            "Lynch",
            "Munoz",
            "Marsh",
            "Hudson",
            "Bartlett",
            "Gregory",
            "Banks",
            "Hood",
            "Fry",
            "Carroll"
        };
        var companies = new[] {
            "Luminary Nexus",
            "CrestWave Dynamics",
            "Horizon Ventures",
            "Sapphire Pulse Technologies",
            "EmberLight Industries",
            "StellarEdge Ventrues",
            "Elysium Crest Holdings"
        };

        for (var i = 0; i < 50; i++)
            persons.Add(
                new Person(
                    names[random.Next(0, names.Length)],
                    surnames[random.Next(0, surnames.Length)],
                    companies[random.Next(0, companies.Length)]
                )
            );

        return persons;
    }

    private void UpdateListViewSelectionMode(int selectionModeIndex) {
        ListViewSelectionMode = selectionModeIndex switch {
            1 => SelectionMode.Multiple,
            2 => SelectionMode.Extended,
            _ => SelectionMode.Single
        };
    }
}