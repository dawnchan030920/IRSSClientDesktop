using IRSSClientDesktop.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace IRSSClientDesktop.Views;

public sealed partial class QQPage : Page
{
    public QQViewModel ViewModel
    {
        get;
    }

    public QQPage()
    {
        ViewModel = App.GetService<QQViewModel>();
        InitializeComponent();
    }
}
