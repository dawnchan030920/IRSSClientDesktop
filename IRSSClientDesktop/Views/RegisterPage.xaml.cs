using IRSSClientDesktop.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace IRSSClientDesktop.Views;

public sealed partial class RegisterPage : Page
{
    public RegisterViewModel ViewModel
    {
        get;
    }

    public RegisterPage()
    {
        ViewModel = App.GetService<RegisterViewModel>();
        InitializeComponent();
    }
}
