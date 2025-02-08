namespace WPFGallery.Controls;

/// <summary>
///     Interaction logic for ColorPageExample.xaml
/// </summary>
[ContentProperty(nameof(ExampleContent))]
public class ColorPageExample : UserControl {
    public static readonly DependencyProperty DescriptionProperty =
        DependencyProperty.Register("Description", typeof(string), typeof(ColorPageExample), new PropertyMetadata(""));

    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register("Title", typeof(string), typeof(ColorPageExample), new PropertyMetadata(""));

    public static readonly DependencyProperty ExampleContentProperty =
        DependencyProperty.Register("ExampleContent", typeof(UIElement), typeof(ColorPageExample),
            new PropertyMetadata(null));

    public string Description {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    public string Title {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public UIElement ExampleContent {
        get => (UIElement)GetValue(ExampleContentProperty);
        set => SetValue(ExampleContentProperty, value);
    }
}