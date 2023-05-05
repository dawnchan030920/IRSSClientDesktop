using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace IRSSClientDesktop.ViewModels;

public partial class RegisterViewModel : ObservableRecipient
{
    [ObservableProperty]
    private string _username;

    [ObservableProperty]
    private string _password;

    [RelayCommand]
    private void Register()
    {
    }

    public RegisterViewModel()
    {
    }
}
