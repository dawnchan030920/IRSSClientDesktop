using System.Collections.ObjectModel;
using System.Windows.Input;
using ABI.Microsoft.UI.Xaml.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IRSSClientDesktop.Contracts.Services;
using IRSSClientDesktop.Core.Models;
using IRSSClientDesktop.Views;

using Microsoft.UI.Xaml.Navigation;

namespace IRSSClientDesktop.ViewModels;

public partial class ShellViewModel : ObservableRecipient
{
    public ObservableCollection<SuggestedItemData> SuggestedItems
    {
        get;
        private set;
    } = new();

    // TODO: Replace by real Search method.
    [RelayCommand]
    private void Search(string input)
    {
        SuggestedItems.Clear();
        foreach (var item in SearchService.GetData(input))
        {
            SuggestedItems.Add(item);
        }

        if (SuggestedItems.Count == 0)
        {
            SuggestedItems.Add(new SuggestedItemData
            {
                Title = "No Result Found"
            });
        }
    }

    [ObservableProperty]
    private bool _isLoggedIn;

    [ObservableProperty]
    private string? _username;

    [RelayCommand]
    private void Logout()
    {

    }

    private bool _isBackEnabled;
    private object? _selected;

    public INavigationService NavigationService
    {
        get;
    }

    public INavigationViewService NavigationViewService
    {
        get;
    }

    public ISearchService SearchService
    {
        get;
    }

    public bool IsBackEnabled
    {
        get => _isBackEnabled;
        set => SetProperty(ref _isBackEnabled, value);
    }

    public object? Selected
    {
        get => _selected;
        set => SetProperty(ref _selected, value);
    }

    public ShellViewModel(INavigationService navigationService, INavigationViewService navigationViewService, ISearchService searchService)
    {
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;
        NavigationViewService = navigationViewService;
        SearchService = searchService;

        // TODO: Change the instant init code to lazy load.
        foreach(var item in searchService.GetData(null))
        {
            SuggestedItems.Add(item);
        }

        IsLoggedIn = false;
        Username = "Dawn Chan";
    }

    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        IsBackEnabled = NavigationService.CanGoBack;

        if (e.SourcePageType == typeof(SettingsPage))
        {
            Selected = NavigationViewService.SettingsItem;
            return;
        }

        var selectedItem = NavigationViewService.GetSelectedItem(e.SourcePageType, e.Parameter);
        if (selectedItem != null)
        {
            Selected = selectedItem;
        }
    }
}
