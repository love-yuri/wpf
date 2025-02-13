﻿using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for DashboardPage.xaml
/// </summary>
public partial class DashboardPage : Page {
    public DashboardPage(DashboardPageViewModel viewModel) {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = this;
    }

    public DashboardPageViewModel ViewModel { get; }
}