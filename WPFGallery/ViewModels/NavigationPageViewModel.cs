using WPFGallery.Models;
using WPFGallery.Navigation;

namespace WPFGallery.ViewModels;

public partial class NavigationPageViewModel : ObservableObject {
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private ICollection<ControlInfoDataItem> _navigationCards =
        ControlsInfoDataSource.Instance.GetControlsInfo("Navigation");

    [ObservableProperty] private string _pageDescription = "Controls for navigation and actions";

    [ObservableProperty] private string _pageTitle = "Navigation";

    public NavigationPageViewModel(INavigationService navigationService) {
        _navigationService = navigationService;
    }

    [RelayCommand]
    public void Navigate(object pageType) {
        if (pageType is Type page) _navigationService.NavigateTo(page);
    }
}