using WPFGallery.Models;
using WPFGallery.Navigation;

namespace WPFGallery.ViewModels;

public partial class CollectionsPageViewModel : ObservableObject {
    private readonly INavigationService _navigationService;


    [ObservableProperty]
    private ICollection<ControlInfoDataItem> _navigationCards =
        ControlsInfoDataSource.Instance.GetControlsInfo("Collections");

    [ObservableProperty] private string _pageDescription = "Controls for collection presentation";

    [ObservableProperty] private string _pageTitle = "Collections";

    public CollectionsPageViewModel(INavigationService navigationService) {
        _navigationService = navigationService;
    }

    [RelayCommand]
    public void Navigate(object pageType) {
        if (pageType is Type page) _navigationService.NavigateTo(page);
    }
}