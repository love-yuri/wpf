namespace WPFGallery.Controls;

/// <summary>
///     Interaction logic for HeaderTile.xaml
/// </summary>
public partial class HeaderTile : UserControl {
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register("Title", typeof(string), typeof(HeaderTile), new PropertyMetadata(""));

    public static readonly DependencyProperty DescriptionProperty =
        DependencyProperty.Register("ColorExplanation", typeof(string), typeof(HeaderTile), new PropertyMetadata(""));

    public static readonly DependencyProperty LinkProperty =
        DependencyProperty.Register("Link", typeof(string), typeof(HeaderTile), new PropertyMetadata(null));

    public static readonly DependencyProperty SourceProperty =
        DependencyProperty.Register("Source", typeof(object), typeof(HeaderTile), new PropertyMetadata(null));

    public HeaderTile() {
        InitializeComponent();
    }

    public string Title {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string Description {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    public string Link {
        get => (string)GetValue(LinkProperty);
        set => SetValue(LinkProperty, value);
    }

    public object Source {
        get => (object)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    private void RootButton_Click(object sender, RoutedEventArgs e) {
        Process.Start(new ProcessStartInfo(Link) { UseShellExecute = true });
    }
}