using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IRSSClientDesktop.Core.Models;

namespace IRSSClientDesktop.ViewModels;

public partial class ZhihuViewModel : ObservableRecipient
{
    public ObservableCollection<AuthorData> SubscribedAuthors
    {
        get;
        set;
    }

    public ObservableCollection<AuthorData> Authors
    {
        get;
        set;
    }

    [ObservableProperty]
    private AuthorData _selectedSubscribedAuthor;

    [ObservableProperty]
    private AuthorData _selectedAuthor;

    [ObservableProperty]
    private string _questionText;

    [RelayCommand]
    private void UnsubscribeAuthor()
    {
        // TODO: Do something
    }

    [RelayCommand]
    private void SearchAuthor()
    {

    }

    [RelayCommand]
    private void AddAuthor()
    {

    }
    public ZhihuViewModel()
    {
    }
}
