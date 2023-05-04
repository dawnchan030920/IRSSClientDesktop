using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IRSSClientDesktop.Core.Models;
using System.Collections.Generic;
using System.Collections;

namespace IRSSClientDesktop.ViewModels;

public partial class QQViewModel : ObservableRecipient
{
    [ObservableProperty]
    private AccountData _selectedAccount;

    [ObservableProperty]
    private string _inputUsername;

    [ObservableProperty]
    private string _inputPassword;

    public ObservableCollection<AccountData> Accounts
    {
        get;
        set;
    }

    public QQViewModel()
    {
        Accounts = new ObservableCollection<AccountData>();

        Accounts.Add(new AccountData() { Id = "1", Username = "qw" });
    }

    [RelayCommand]
    private void DeleteAccount()
    {
        // TODO: Do something.
    }

    [RelayCommand]
    private void AddAccount()
    {
        // TODO: Do something.
        InputPassword = string.Empty;
        InputUsername = string.Empty;
    }
}
