using CommunityToolkit.WinUI.UI.Controls;

using IRSSClientDesktop.ViewModels;

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

    private void OnViewStateChanged(object sender, ListDetailsViewState e)
    {
        if (e == ListDetailsViewState.Both)
        {
            ViewModel.EnsureItemSelected();
        }
    }
}
