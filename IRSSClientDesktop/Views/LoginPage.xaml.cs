using IRSSClientDesktop.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace IRSSClientDesktop.Views;

public sealed partial class LoginPage : Page
{
    public LoginViewModel ViewModel
    {
        get;
    }

    public LoginPage()
    {
        ViewModel = App.GetService<LoginViewModel>();
        InitializeComponent();
    }
}
