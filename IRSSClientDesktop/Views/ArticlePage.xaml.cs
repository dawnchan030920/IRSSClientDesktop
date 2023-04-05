using IRSSClientDesktop.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace IRSSClientDesktop.Views;

public sealed partial class ArticlePage : Page
{
    public ArticleViewModel ViewModel
    {
        get;
    }

    public ArticlePage()
    {
        ViewModel = App.GetService<ArticleViewModel>();
        InitializeComponent();
    }
}
