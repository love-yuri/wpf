namespace WPFGallery.ViewModels;

public partial class CheckBoxPageViewModel : ObservableObject {
    [ObservableProperty] private bool _optionOneCheckBoxChecked;

    [ObservableProperty] private bool _optionThreeCheckBoxChecked;

    [ObservableProperty] private bool _optionTwoCheckBoxChecked = true;

    [ObservableProperty] private string _pageDescription = "";

    [ObservableProperty] private string _pageTitle = "CheckBox";

    [ObservableProperty] private bool? _selectAllCheckBoxChecked;

    [RelayCommand]
    private void OnSelectAllChecked(object sender) {
        if (sender is not CheckBox checkBox)
            return;

        if (checkBox.IsChecked == null)
            checkBox.IsChecked = !(
                OptionOneCheckBoxChecked && OptionTwoCheckBoxChecked && OptionThreeCheckBoxChecked
            );

        if (checkBox.IsChecked == true) {
            OptionOneCheckBoxChecked = true;
            OptionTwoCheckBoxChecked = true;
            OptionThreeCheckBoxChecked = true;
        } else if (checkBox.IsChecked == false) {
            OptionOneCheckBoxChecked = false;
            OptionTwoCheckBoxChecked = false;
            OptionThreeCheckBoxChecked = false;
        }
    }

    [RelayCommand]
    private void OnSingleChecked(string option) {
        if (OptionOneCheckBoxChecked && OptionTwoCheckBoxChecked && OptionThreeCheckBoxChecked)
            SelectAllCheckBoxChecked = true;
        else if (!OptionOneCheckBoxChecked && !OptionTwoCheckBoxChecked && !OptionThreeCheckBoxChecked)
            SelectAllCheckBoxChecked = false;
        else
            SelectAllCheckBoxChecked = null;
    }
}