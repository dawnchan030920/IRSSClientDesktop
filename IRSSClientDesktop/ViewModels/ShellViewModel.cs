using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IRSSClientDesktop.Contracts.Services;
using IRSSClientDesktop.Core.Models;
using IRSSClientDesktop.Views;

using Microsoft.UI.Xaml.Navigation;

namespace IRSSClientDesktop.ViewModels;

public partial class ShellViewModel : ObservableRecipient
{
    public ObservableCollection<SourceItemData> Sources
    {
        get;
        private set;
    } = new()
    {
        new SourceItemData() { Account = "dc392", Platform = SourcePlatform.Bilibili }
    };

    // TODO: Replace by real AddSource method.
    [RelayCommand]
    private void AddSource()
    {
        Sources.Add(new SourceItemData() { Account = "127", Platform = SourcePlatform.QQ });
        NavigationService.NavigateTo(typeof(HomeViewModel).FullName, null, true);
    }

    // TODO: Replace by real DeleteSource method.
    [RelayCommand]
    private void DeleteSource(SourceItemData source)
    {
        Sources.Remove(source);
        NavigationService.NavigateTo(typeof(HomeViewModel).FullName, null, true);
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

    public ShellViewModel(INavigationService navigationService, INavigationViewService navigationViewService)
    {
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;
        NavigationViewService = navigationViewService;
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
