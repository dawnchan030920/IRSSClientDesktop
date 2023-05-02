using CommunityToolkit.Mvvm.ComponentModel;

namespace IRSSClientDesktop.ViewModels;

public partial class MessageViewModel : ObservableRecipient
{
    [ObservableProperty] private int _selectedIndex;

    public MessageViewModel()
    {
    }
}
