using CommunityToolkit.WinUI.UI.Controls;

using IRSSClientDesktop.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace IRSSClientDesktop.Views;

public sealed partial class NotePage : Page
{
    public NoteViewModel ViewModel
    {
        get;
    }

    public NotePage()
    {
        ViewModel = App.GetService<NoteViewModel>();
        InitializeComponent();
    }

    private void UploadNoteButton_Clicked(object sender, RoutedEventArgs e)
    {
        ViewModel.UploadNoteCommand.Execute(null);
    }
}
