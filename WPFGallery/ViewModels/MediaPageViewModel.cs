using WPFGallery.Models;
using WPFGallery.Navigation;

namespace WPFGallery.ViewModels;

public partial class MediaPageViewModel : ObservableObject {
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private ICollection<ControlInfoDataItem>
        _navigationCards = ControlsInfoDataSource.Instance.GetControlsInfo("Media");

    [ObservableProperty] private string _pageDescription = "Controls for media presentation";

    [ObservableProperty] private string _pageTitle = "Media Controls";

    public MediaPageViewModel(INavigationService navigationService) {
        _navigationService = navigationService;
    }

    [RelayCommand]
    public void Navigate(object pageType) {
        if (pageType is Type page) _navigationService.NavigateTo(page);
    }
}