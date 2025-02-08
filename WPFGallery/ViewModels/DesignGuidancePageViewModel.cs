using WPFGallery.Models;
using WPFGallery.Navigation;

namespace WPFGallery.ViewModels;

public partial class DesignGuidancePageViewModel : ObservableObject {
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private ICollection<ControlInfoDataItem> _navigationCards =
        ControlsInfoDataSource.Instance.GetControlsInfo("Design Guidance");

    [ObservableProperty] private string _pageDescription =
        "Design guidelines on how to use colors, typography, and icons in your app.";

    [ObservableProperty] private string _pageTitle = "Design Guidance";

    public DesignGuidancePageViewModel(INavigationService navigationService) {
        _navigationService = navigationService;
    }

    [RelayCommand]
    public void Navigate(object pageType) {
        if (pageType is Type page) _navigationService.NavigateTo(page);
    }
}