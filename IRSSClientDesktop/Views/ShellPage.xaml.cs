using System.Collections.Specialized;
using IRSSClientDesktop.Contracts.Services;
using IRSSClientDesktop.Helpers;
using IRSSClientDesktop.ViewModels;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;

using Windows.System;
using IRSSClientDesktop.Core.Models;

namespace IRSSClientDesktop.Views;

// TODO: Update NavigationViewItem titles and icons in ShellPage.xaml.
public sealed partial class ShellPage : Page
{
    public ShellViewModel ViewModel
    {
        get;
    }

    public ShellPage(ShellViewModel viewModel)
    {
        ViewModel = viewModel;
        InitializeComponent();

        ViewModel.NavigationService.Frame = NavigationFrame;
        ViewModel.NavigationViewService.Initialize(NavigationViewControl);

        ViewModel.Sources.CollectionChanged += OnSourceUpdated!;

        // TODO: Set the title bar icon by updating /Assets/WindowIcon.ico.
        // A custom title bar is required for full window theme and Mica support.
        // https://docs.microsoft.com/windows/apps/develop/title-bar?tabs=winui3#full-customization
        App.MainWindow.ExtendsContentIntoTitleBar = true;
        App.MainWindow.SetTitleBar(AppTitleBar);
        App.MainWindow.Activated += MainWindow_Activated;
        AppTitleBarText.Text = ResourceExtensions.GetLocalized("AppDisplayName");

        // Set source sub items.
        UpdateSource();
    }

    private void OnSourceUpdated(object sender, NotifyCollectionChangedEventArgs e)
    {
        UpdateSource();
    }

    private void OnAutoSuggestBoxTextChanged(object sender, AutoSuggestBoxTextChangedEventArgs e)
    {
        if (sender is AutoSuggestBox box && e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
        {
            ViewModel.SearchCommand.Execute(box.Text);
        }
    }

    private void UpdateSource()
    {
        SourceItemRoot.MenuItems.Clear();
        foreach (var item in ViewModel.Sources)
        {
            var container = new NavigationViewItem
            {
                Content = $"{item.Platform} - {item.Account}",
                Tag = item,
                ContextFlyout = new MenuFlyout
                {
                    Items =
                    {
                        new MenuFlyoutItem()
                        {
                            Text = "SourceItemFlyout_Delete/Text".GetLocalized(),
                            Icon = new FontIcon()
                            {
                                Glyph = "\uE74D"
                            },
                            CommandParameter = item,
                            Command = ViewModel.DeleteSourceCommand
                        }
                    }
                }
            };
            NavigationHelper.SetNavigateTo(container, typeof(SourceViewModel).FullName);
            SourceItemRoot.MenuItems.Add(container);
        }
    }

    private void OnLoaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        KeyboardAccelerators.Add(BuildKeyboardAccelerator(VirtualKey.Left, VirtualKeyModifiers.Menu));
        KeyboardAccelerators.Add(BuildKeyboardAccelerator(VirtualKey.GoBack));
    }

    private void MainWindow_Activated(object sender, WindowActivatedEventArgs args)
    {
        var resource = args.WindowActivationState == WindowActivationState.Deactivated ? "WindowCaptionForegroundDisabled" : "WindowCaptionForeground";

        AppTitleBarText.Foreground = (SolidColorBrush)App.Current.Resources[resource];
    }

    private void NavigationViewControl_DisplayModeChanged(NavigationView sender, NavigationViewDisplayModeChangedEventArgs args)
    {
        AppTitleBar.Margin = new Thickness()
        {
            Left = sender.CompactPaneLength * (sender.DisplayMode == NavigationViewDisplayMode.Minimal ? 2 : 1),
            Top = AppTitleBar.Margin.Top,
            Right = AppTitleBar.Margin.Right,
            Bottom = AppTitleBar.Margin.Bottom
        };
    }

    private static KeyboardAccelerator BuildKeyboardAccelerator(VirtualKey key, VirtualKeyModifiers? modifiers = null)
    {
        var keyboardAccelerator = new KeyboardAccelerator() { Key = key };

        if (modifiers.HasValue)
        {
            keyboardAccelerator.Modifiers = modifiers.Value;
        }

        keyboardAccelerator.Invoked += OnKeyboardAcceleratorInvoked;

        return keyboardAccelerator;
    }

    private static void OnKeyboardAcceleratorInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
    {
        var navigationService = App.GetService<INavigationService>();

        var result = navigationService.GoBack();

        args.Handled = result;
    }
}