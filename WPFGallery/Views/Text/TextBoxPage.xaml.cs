﻿using WPFGallery.ViewModels;

namespace WPFGallery.Views;

/// <summary>
///     Interaction logic for TextBoxPage.xaml
/// </summary>
public partial class TextBoxPage : Page {
    public TextBoxPage(TextBoxPageViewModel viewModel) {
        ViewModel = viewModel;
        DataContext = this;
        InitializeComponent();
    }

    public TextBoxPageViewModel ViewModel { get; }
}