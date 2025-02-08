﻿using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for DatePickerPage.xaml
/// </summary>
public partial class DatePickerPage : Page {
    public DatePickerPage(DatePickerPageViewModel viewModel) {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }

    public DatePickerPageViewModel ViewModel { get; }
}