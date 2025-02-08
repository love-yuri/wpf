using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for RadioButtonPage.xaml
/// </summary>
public partial class RadioButtonPage : Page {
    public RadioButtonPage(RadioButtonPageViewModel viewModel) {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }

    public RadioButtonPageViewModel ViewModel { get; }

    private void RadioButton_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) {
        var radioButton = sender as RadioButton;
        if (radioButton != null) radioButton.IsChecked = true;
    }
}