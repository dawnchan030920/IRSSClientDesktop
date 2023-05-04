using IRSSClientDesktop.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace IRSSClientDesktop.Views;

public sealed partial class BilibiliPage : Page
{
    public BilibiliViewModel ViewModel
    {
        get;
    }

    public BilibiliPage()
    {
        ViewModel = App.GetService<BilibiliViewModel>();
        InitializeComponent();
    }
}
