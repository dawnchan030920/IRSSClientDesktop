using CommunityToolkit.Labs.WinUI;
using IRSSClientDesktop.Core.Models;
using IRSSClientDesktop.ViewModels;
using Microsoft.UI.Xaml;
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

    private void MessageTopicFavorite_Click(object sender, RoutedEventArgs e)
    {
        // TODO
    }

    private void MessageMentionFavorite_Click(object sender, RoutedEventArgs e)
    {
        // TODO
    }

    private void MessageSummaryFavorite_Click(object sender, RoutedEventArgs e)
    {
        // TODO
    }
}
