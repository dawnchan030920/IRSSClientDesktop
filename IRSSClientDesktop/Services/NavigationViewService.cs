using System.Diagnostics.CodeAnalysis;

using IRSSClientDesktop.Contracts.Services;
using IRSSClientDesktop.Helpers;
using IRSSClientDesktop.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace IRSSClientDesktop.Services;

public class NavigationViewService : INavigationViewService
{
    private readonly INavigationService _navigationService;

    private readonly IPageService _pageService;

    private NavigationView? _navigationView;

    public IList<object>? MenuItems => _navigationView?.MenuItems;

    public object? SettingsItem => _navigationView?.SettingsItem;

    public NavigationViewService(INavigationService navigationService, IPageService pageService)
    {
        _navigationService = navigationService;
        _pageService = pageService;
    }

    [MemberNotNull(nameof(_navigationView))]
    public void Initialize(NavigationView navigationView)
    {
        _navigationView = navigationView;
        _navigationView.BackRequested += OnBackRequested;
        _navigationView.ItemInvoked += OnItemInvoked;
    }

    public void UnregisterEvents()
    {
        if (_navigationView != null)
        {
            _navigationView.BackRequested -= OnBackRequested;
            _navigationView.ItemInvoked -= OnItemInvoked;
        }
    }

    public NavigationViewItem? GetSelectedItem(Type pageType, object? parameter)
    {
        if (_navigationView != null)
        {
            return GetSelectedItem(_navigationView.MenuItems, pageType, parameter) ?? GetSelectedItem(_navigationView.FooterMenuItems, pageType, parameter);
        }

        return null;
    }

    private void OnBackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args) => _navigationService.GoBack();


    /// <summary>
    /// Event handler for NavigationView.ItemInvoked.
    /// </summary>
    /// <remarks>Tag property of the selected item will be sent as the parameter of Navigation Service.</remarks>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        if (args.IsSettingsInvoked)
        {
            _navigationService.NavigateTo(typeof(SettingsViewModel).FullName!);
        }
        else
        {
            var selectedItem = args.InvokedItemContainer as NavigationViewItem;

            if (selectedItem?.GetValue(NavigationHelper.NavigateToProperty) is string pageKey)
            {
                _navigationService.NavigateTo(pageKey, selectedItem.Tag);
            }
        }
    }

    // TODO: Parameter to support navigation among same page with different data.
    private NavigationViewItem? GetSelectedItem(IEnumerable<object> menuItems, Type pageType, object? parameter)
    {
        foreach (var item in menuItems.OfType<NavigationViewItem>())
        {
            if (IsMenuItemForPageType(item, pageType, parameter))
            {
                return item;
            }

            var selectedChild = GetSelectedItem(item.MenuItems, pageType, parameter);
            if (selectedChild != null)
            {
                return selectedChild;
            }
        }

        return null;
    }

    private bool IsMenuItemForPageType(NavigationViewItem menuItem, Type sourcePageType, object? parameter)
    {
        if (menuItem.GetValue(NavigationHelper.NavigateToProperty) is string pageKey)
        {
            return _pageService.GetPageType(pageKey) == sourcePageType && (menuItem.Tag == null || menuItem.Tag.Equals(parameter));
        }

        return false;
    }
}
