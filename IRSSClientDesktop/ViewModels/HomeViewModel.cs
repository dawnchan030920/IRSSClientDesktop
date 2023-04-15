using CommunityToolkit.Mvvm.ComponentModel;

namespace IRSSClientDesktop.ViewModels;

public partial class HomeViewModel : ObservableRecipient
{
    [ObservableProperty]
    private bool _isPaneOpen;

    public HomeViewModel()
    {
    }
}
