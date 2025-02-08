using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for WhatsNewPage.xaml
/// </summary>
public partial class WhatsNewPage : Page {
    public WhatsNewPage(WhatsNewPageViewModel viewModel) {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = this;
    }

    public WhatsNewPageViewModel ViewModel { get; }

    private void Open_WhatsNewPage(object sender, RoutedEventArgs e) {
        Process.Start(new ProcessStartInfo("https://learn.microsoft.com/en-in/dotnet/desktop/wpf/whats-new/net90")
            { UseShellExecute = true });
    }

    private void Open_UsingFluentInWPFPage(object sender, RoutedEventArgs e) {
        Process.Start(new ProcessStartInfo("https://aka.ms/wpf-fluentdoc") { UseShellExecute = true });
    }
}