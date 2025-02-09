﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wpf_net9.Navigation;
using Wpf_net9.ViewModels;
using Wpf_net9.Views;

namespace Wpf_net9;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App {
    protected override void OnStartup(StartupEventArgs e) {
        base.OnStartup(e);
        DispatcherUnhandledException += (_, args) => {
            var hasHandled = false;
            var msg = "主ui线程发现错误!";
            switch (args.Exception) {
                case NullReferenceException: {
                    hasHandled = true;
                    msg = "出现空引用!";
                    break;
                }
            }
            MessageBox.Show(msg);
            args.Handled = hasHandled;
        };
    }

    /// <summary>
    /// di依赖注入
    /// </summary>
    private static readonly IHost Host = Microsoft.Extensions.Hosting.Host
        .CreateDefaultBuilder()
        .ConfigureServices((_, service) => {
            service.AddTransient<MainWindowViewModel>(); // 返回局部实例，只有短暂的作用域
            service.AddSingleton<MainWindow>(); // 返回单例实例，整个应用程序周期内只有一个实例

            service.AddSingleton<NavigationService>();
            service.AddSingleton<HomePage>();

        })
        .Build();

    [STAThread]
    public static void Main() {
        // 启动service 服务
        Host.Start();

        var app = new App();
        app.InitializeComponent();
        var window = Host.Services.GetRequiredService<MainWindow>();
        window.Visibility = Visibility.Visible;
        app.Run();
    }
}
