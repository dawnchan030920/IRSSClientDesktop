﻿using Windows.System;
using IRSSClientDesktop.ViewModels;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;

namespace IRSSClientDesktop.Views;

public sealed partial class ArticlePage : Page
{
    public ArticleViewModel ViewModel
    {
        get;
    }

    public ArticlePage()
    {
        ViewModel = App.GetService<ArticleViewModel>();
        InitializeComponent();
    }
}
