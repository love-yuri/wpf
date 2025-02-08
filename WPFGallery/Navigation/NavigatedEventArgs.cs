namespace WPFGallery.Navigation;

/// <summary>
///     Event arguments for the Navigating event.
/// </summary>
public class NavigatingEventArgs {
    public NavigatingEventArgs() { }

    public NavigatingEventArgs(Type pageType) {
        PageType = pageType;
    }

    public Type? PageType { get; set; }
}