namespace WPFGallery.ViewModels;

public partial class SliderPageViewModel : ObservableObject {
    [ObservableProperty] private int _marksSliderValue;

    [ObservableProperty] private string _pageDescription = "";

    [ObservableProperty] private string _pageTitle = "Slider";

    [ObservableProperty] private int _rangeSliderValue = 500;

    [ObservableProperty] private int _simpleSliderValue;

    [ObservableProperty] private int _verticalSliderValue;
}