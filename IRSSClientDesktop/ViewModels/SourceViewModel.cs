using CommunityToolkit.Mvvm.ComponentModel;
using IRSSClientDesktop.Contracts.ViewModels;
using IRSSClientDesktop.Core.Models;

namespace IRSSClientDesktop.ViewModels;

public partial class SourceViewModel : ObservableRecipient, INavigationAware
{
    [ObservableProperty]
    private string _account;

    [ObservableProperty]
    private Platform _platform;

    public SourceViewModel()
    {
    }

    public void OnNavigatedTo(object parameter)
    {
        if (parameter is SourceItemData source)
        {
            Account = source.Account;
            Platform = source.Platform;
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
