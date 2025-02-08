using WPFGallery.Models;
using WPFGallery.Navigation;

namespace WPFGallery.ViewModels;

public partial class DateAndTimePageViewModel : ObservableObject {
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private ICollection<ControlInfoDataItem> _navigationCards =
        ControlsInfoDataSource.Instance.GetControlsInfo("Date & Calendar");

    [ObservableProperty] private string _pageDescription = "Controls for date and calendar";

    [ObservableProperty] private string _pageTitle = "Date & Calendar";

    public DateAndTimePageViewModel(INavigationService navigationService) {
        _navigationService = navigationService;
    }

    [RelayCommand]
    public void Navigate(object pageType) {
        if (pageType is Type page) _navigationService.NavigateTo(page);
    }
}