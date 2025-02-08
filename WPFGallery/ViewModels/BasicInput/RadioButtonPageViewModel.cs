namespace WPFGallery.ViewModels;

public partial class RadioButtonPageViewModel : ObservableObject {
    [ObservableProperty] private bool _isRadioButtonEnabled = true;

    [ObservableProperty] private string _pageDescription = "";

    [ObservableProperty] private string _pageTitle = "RadioButton";

    [RelayCommand]
    private void OnRadioButtonCheckboxChecked(object sender) {
        if (sender is not CheckBox checkbox)
            return;

        IsRadioButtonEnabled = !(checkbox?.IsChecked ?? false);
    }
}