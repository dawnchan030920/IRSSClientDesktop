using IRSSClientDesktop.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace IRSSClientDesktop.Views;

public sealed partial class SourcePage : Page
{
    public SourceViewModel ViewModel
    {
        get;
    }

    public SourcePage()
    {
        ViewModel = App.GetService<SourceViewModel>();
        InitializeComponent();
    }
}
