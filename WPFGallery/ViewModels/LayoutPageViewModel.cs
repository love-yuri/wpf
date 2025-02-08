using WPFGallery.Models;
using WPFGallery.Navigation;

namespace WPFGallery.ViewModels;

public partial class LayoutPageViewModel : ObservableObject {
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private ICollection<ControlInfoDataItem> _navigationCards =
        ControlsInfoDataSource.Instance.GetControlsInfo("Layout");

    [ObservableProperty] private string _pageDescription = "Controls for layouting";

    [ObservableProperty] private string _pageTitle = "Layout";

    public LayoutPageViewModel(INavigationService navigationService) {
        _navigationService = navigationService;
    }

    [RelayCommand]
    public void Navigate(object pageType) {
        if (pageType is Type page) _navigationService.NavigateTo(page);
    }
}