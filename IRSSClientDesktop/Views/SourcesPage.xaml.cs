using CommunityToolkit.WinUI.UI.Controls;

using IRSSClientDesktop.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace IRSSClientDesktop.Views;

public sealed partial class SourcesPage : Page
{
    public SourcesViewModel ViewModel
    {
        get;
    }

    public SourcesPage()
    {
        ViewModel = App.GetService<SourcesViewModel>();
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
