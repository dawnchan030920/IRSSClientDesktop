using IRSSClientDesktop.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace IRSSClientDesktop.Views;

public sealed partial class HomePage : Page
{
    public HomeViewModel ViewModel
    {
        get;
    }

    public HomePage()
    {
        ViewModel = App.GetService<HomeViewModel>();
        InitializeComponent();
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new ContentDialog();
        dialog.XamlRoot = this.XamlRoot;
        dialog.CloseButtonText = "取消";
        dialog.Title = "登录";
        dialog.Content = App.GetService<LoginPage>();
        dialog.ShowAsync();
    }

    private void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new ContentDialog();
        dialog.XamlRoot = this.XamlRoot;
        dialog.CloseButtonText = "取消";
        dialog.Title = "注册";
        dialog.Content = App.GetService<RegisterPage>();
        dialog.ShowAsync();
    }
}
