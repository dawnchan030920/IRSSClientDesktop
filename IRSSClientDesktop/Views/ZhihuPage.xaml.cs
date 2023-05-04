using IRSSClientDesktop.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace IRSSClientDesktop.Views;

public sealed partial class ZhihuPage : Page
{
    public ZhihuViewModel ViewModel
    {
        get;
    }

    public ZhihuPage()
    {
        ViewModel = App.GetService<ZhihuViewModel>();
        InitializeComponent();
    }
}
