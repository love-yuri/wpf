using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace Wpf_net9.Navigation;

public class NavigationService(IServiceProvider serviceProvider) {
    private Frame? _frame;

    /**
     * 导航到指定页面
     */
    public void GoTo(Type type) {
        var page = serviceProvider.GetRequiredService(type);
        _frame?.Navigate(page);
    }

    /**
     * 设置frame
     */
    public void SetFrame(Frame frame) {
        _frame = frame;
    }
}
