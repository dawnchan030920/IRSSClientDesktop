using IRSSClientDesktop.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace IRSSClientDesktop.Views;

public sealed partial class MessagePage : Page
{
    public MessageViewModel ViewModel
    {
        get;
    }

    public MessagePage()
    {
        ViewModel = App.GetService<MessageViewModel>();
        InitializeComponent();
    }
}
