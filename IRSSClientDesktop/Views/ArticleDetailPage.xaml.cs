using IRSSClientDesktop.Core.Models;
using IRSSClientDesktop.ViewModels;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace IRSSClientDesktop.Views;

public sealed partial class ArticleDetailPage : Page
{
    public ArticleDetailViewModel ViewModel
    {
        get;
    }

    public ArticleDetailPage()
    {
        ViewModel = App.GetService<ArticleDetailViewModel>();
        InitializeComponent();
    }
}
