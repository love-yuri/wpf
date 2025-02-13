﻿using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Controls.Primitives;
using System.Windows.Navigation;
using System.Windows.Shell;
using Microsoft.Win32;
using WPFGallery.Helpers;
using WPFGallery.Models;
using WPFGallery.Navigation;
using WPFGallery.ViewModels;
using WPFGallery.Views;

namespace WPFGallery;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow {
    private readonly INavigationService _navigationService;

    public MainWindow(MainWindowViewModel viewModel, INavigationService navigationService) {
        ViewModel = viewModel;
        DataContext = this;
        InitializeComponent();

        UpdateWindowBackground();
        UpdateTitleBarButtonsVisibility();

        _navigationService = navigationService;
        _navigationService.Navigating += OnNavigating;
        _navigationService.SetFrame(RootContentFrame);
        _navigationService.Navigate(typeof(DashboardPage));

        WindowChrome.SetWindowChrome(this, new WindowChrome {
            CaptionHeight = 50,
            CornerRadius = default,
            GlassFrameThickness = new Thickness(-1),
            ResizeBorderThickness = ResizeMode == ResizeMode.NoResize ? default : new Thickness(4),
            UseAeroCaptionButtons = true
        });

        SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
        StateChanged += MainWindow_StateChanged;
    }

    public MainWindowViewModel ViewModel { get; }

    private void UpdateWindowBackground() {
        if (!Utility.IsBackdropDisabled() && !Utility.IsBackdropSupported()) {
            SetResourceReference(BackgroundProperty, "WindowBackground");
        }
    }

    private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e) {
        Dispatcher.Invoke(UpdateTitleBarButtonsVisibility);
    }

    private void MainWindow_StateChanged(object? sender, EventArgs e) {
        MainGrid.Margin = WindowState == WindowState.Maximized ? new Thickness(8) : default;
    }

    private void ControlsList_SelectedItemChanged() {
        if (ControlsList.SelectedItem is ControlInfoDataItem navItem) {
            _navigationService.Navigate(navItem.PageType);
            if (ControlsList.ItemContainerGenerator.ContainerFromItem(navItem) is TreeViewItem tvi) {
                tvi.BringIntoView();
            }
        }
    }

    private void UpdateTitleBarButtonsVisibility() {
        if (Utility.IsBackdropDisabled() || !Utility.IsBackdropSupported() ||
            SystemParameters.HighContrast) {
            MinimizeButton.Visibility = Visibility.Visible;
            MaximizeButton.Visibility = Visibility.Visible;
            CloseButton.Visibility = Visibility.Visible;
        } else {
            MinimizeButton.Visibility = Visibility.Collapsed;
            MaximizeButton.Visibility = Visibility.Collapsed;
            CloseButton.Visibility = Visibility.Collapsed;
        }
    }

    private void MinimizeWindow(object sender, RoutedEventArgs e) {
        WindowState = WindowState.Minimized;
    }

    private void MaximizeWindow(object sender, RoutedEventArgs e) {
        if (WindowState == WindowState.Maximized) {
            WindowState = WindowState.Normal;
            MaximizeIcon.Text = "\uE922";
        } else {
            WindowState = WindowState.Maximized;
            MaximizeIcon.Text = "\uE923";
        }
    }

    private void CloseWindow(object sender, RoutedEventArgs e) {
        Application.Current.Shutdown();
    }

    private void OnNavigating(object? sender, NavigatingEventArgs e) {
        var list = ViewModel.GetNavigationItemHierarchyFromPageType(e.PageType);

        if (list.Count > 0) {
            TreeViewItem? selectedTreeViewItem = null;
            ItemsControl itemsControl = ControlsList;
            foreach (var tvi in list.Select(
                item => itemsControl.ItemContainerGenerator.ContainerFromItem(item)
            ).OfType<TreeViewItem>()) {
                tvi.IsExpanded = true;
                tvi.UpdateLayout();
                itemsControl = tvi;
                selectedTreeViewItem = tvi;
            }

            if (selectedTreeViewItem != null) {
                selectedTreeViewItem.IsSelected = true;
                ControlsList_SelectedItemChanged();
            }
        }
    }

    private void RootContentFrame_Navigated(object sender, NavigationEventArgs e) {
        ViewModel.UpdateCanNavigateBack();
    }

    private void SelectedItemChanged(TreeViewItem? tvi) {
        ControlsList_SelectedItemChanged();
        if (tvi != null) {
            tvi.IsExpanded = !tvi.IsExpanded;
        }
    }

    private void ControlsList_PreviewKeyDown(object sender, KeyEventArgs e) {
        if (e.Key == Key.Enter)
            SelectedItemChanged(
                ControlsList.ItemContainerGenerator.ContainerFromItem((sender as TreeView)
                    ?.SelectedItem) as TreeViewItem);
    }

    private void ControlsList_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
        if (e.OriginalSource is ToggleButton) return;

        SelectedItemChanged(
            ControlsList.ItemContainerGenerator.ContainerFromItem((sender as TreeView)?.SelectedItem) as TreeViewItem);
    }

    private void SettingsButton_Click(object sender, RoutedEventArgs e) {
        var peer = UIElementAutomationPeer.CreatePeerForElement((Button)sender);
        peer.RaiseNotificationEvent(
            AutomationNotificationKind.Other,
            AutomationNotificationProcessing.ImportantMostRecent,
            "Settings Page Opened",
            "ButtonClickedActivity"
        );
    }

    private void ControlsList_Loaded(object sender, RoutedEventArgs e) {
        if (ControlsList.Items.Count > 0) {
            var firstItem =
                (TreeViewItem)ControlsList.ItemContainerGenerator.ContainerFromItem(ControlsList.Items[0]);
            if (firstItem != null) firstItem.IsSelected = true;
        }
    }
}