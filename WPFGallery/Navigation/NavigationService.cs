namespace WPFGallery.Navigation;

/// <summary>
///     Interface for the NavigationService
/// </summary>
public interface INavigationService {
    void Navigate(Type type);
    void NavigateTo(Type type);
    void SetFrame(Frame frame);
    void NavigateBack();
    void NavigateForward();
    bool IsBackHistoryNonEmpty();
    event EventHandler<NavigatingEventArgs> Navigating;
}

/// <summary>
///     Service for navigating between pages.
/// </summary>
public class NavigationService(IServiceProvider serviceProvider) : INavigationService {
    private readonly Stack<Type?> _future = new();
    private readonly Stack<Type?> _history = new();
    private Type? _currentPageType;
    private Frame? _frame;
    public event EventHandler<NavigatingEventArgs>? Navigating;

    public void SetFrame(Frame frame) {
        _frame = frame;
    }

    public void NavigateTo(Type type) {
        _future.Clear();
        RaiseNavigatingEvent(type);
    }

    public void Navigate(Type type) {
        _history.Push(_currentPageType);
        _currentPageType = type;
        var page = serviceProvider.GetRequiredService(type);
        _frame?.Navigate(page);
    }

    public void NavigateBack() {
        if (_history.Count <= 0) return;
        var type = _history.Pop();
        if (type == null) return;
        _future.Push(type);
        RaiseNavigatingEvent(type);
        _history.Pop();
    }

    public void NavigateForward() {
        if (_future.Count <= 0) return;
        var type = _future.Pop();
        if (type == null) return;
        _history.Push(type);
        RaiseNavigatingEvent(type);
    }

    public bool IsBackHistoryNonEmpty() {
        var item = _history.Peek();
        return item != null;
    }

    private void RaiseNavigatingEvent(Type type) {
        Navigating?.Invoke(this, new NavigatingEventArgs(type));
    }
}