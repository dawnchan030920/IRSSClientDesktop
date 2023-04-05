using IRSSClientDesktop.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace IRSSClientDesktop.Views;

public sealed partial class AnswerPage : Page
{
    public AnswerViewModel ViewModel
    {
        get;
    }

    public AnswerPage()
    {
        ViewModel = App.GetService<AnswerViewModel>();
        InitializeComponent();
    }
}
