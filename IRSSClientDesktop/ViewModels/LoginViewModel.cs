using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace IRSSClientDesktop.ViewModels;

public partial class LoginViewModel : ObservableRecipient
{
    [ObservableProperty]
    private string _username;

    [ObservableProperty]
    private string _password;

    [RelayCommand]
    private void Login()
    {
    }

    public LoginViewModel()
    {
    }
}
