using WPFGallery.Models;
using WPFGallery.Navigation;

namespace WPFGallery.ViewModels;

public partial class StatusAndInfoPageViewModel : ObservableObject {
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private ICollection<ControlInfoDataItem> _navigationCards =
        ControlsInfoDataSource.Instance.GetControlsInfo("Status & Info");

    [ObservableProperty] private string _pageDescription = "Controls to show progress and extra information";

    [ObservableProperty] private string _pageTitle = "Status & Info";

    public StatusAndInfoPageViewModel(INavigationService navigationService) {
        _navigationService = navigationService;
    }

    [RelayCommand]
    public void Navigate(object pageType) {
        if (pageType is Type page) _navigationService.NavigateTo(page);
    }
}