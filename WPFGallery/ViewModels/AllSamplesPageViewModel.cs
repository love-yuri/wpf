using WPFGallery.Models;
using WPFGallery.Navigation;

namespace WPFGallery.ViewModels;

public partial class AllSamplesPageViewModel : ObservableObject {
    private readonly INavigationService _navigationService;

    [ObservableProperty]
    private ICollection<ControlInfoDataItem> _navigationCards = ControlsInfoDataSource.Instance.GetAllControlsInfo();

    [ObservableProperty] private string _pageDescription = "";

    [ObservableProperty] private string _pageTitle = "All Controls";

    public AllSamplesPageViewModel(INavigationService navigationService) {
        _navigationService = navigationService;
    }

    [RelayCommand]
    public void Navigate(object pageType) {
        if (pageType is Type page) _navigationService.NavigateTo(page);
    }
}