using IRSSClientDesktop.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace IRSSClientDesktop.Views;

public sealed partial class WechatPage : Page
{
    public WechatViewModel ViewModel
    {
        get;
    }

    public WechatPage()
    {
        ViewModel = App.GetService<WechatViewModel>();
        InitializeComponent();
    }
}
