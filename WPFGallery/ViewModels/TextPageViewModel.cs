using WPFGallery.Models;
using WPFGallery.Navigation;

namespace WPFGallery.ViewModels;

public partial class TextPageViewModel : ObservableObject {
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private ICollection<ControlInfoDataItem> _navigationCards = ControlsInfoDataSource.Instance.GetControlsInfo("Text");

    [ObservableProperty] private string _pageDescription = "Controls for displaying and editing text";

    [ObservableProperty] private string _pageTitle = "Text";

    public TextPageViewModel(INavigationService navigationService) {
        _navigationService = navigationService;
    }

    [RelayCommand]
    public void Navigate(object pageType) {
        if (pageType is Type page) _navigationService.NavigateTo(page);
    }
}