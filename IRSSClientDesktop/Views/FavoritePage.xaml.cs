using CommunityToolkit.WinUI.UI.Controls;

using IRSSClientDesktop.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace IRSSClientDesktop.Views;

public sealed partial class FavoritePage : Page
{
    public FavoriteViewModel ViewModel
    {
        get;
    }

    public FavoritePage()
    {
        ViewModel = App.GetService<FavoriteViewModel>();
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
