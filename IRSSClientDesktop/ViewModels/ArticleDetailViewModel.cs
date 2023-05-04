using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IRSSClientDesktop.Contracts.ViewModels;
using IRSSClientDesktop.Core.Models;

namespace IRSSClientDesktop.ViewModels;

public partial class ArticleDetailViewModel : ObservableRecipient, INavigationAware
{
    [ObservableProperty]
    private string _title;

    [ObservableProperty]
    private DateTime _time;

    [ObservableProperty]
    private string _topic;

    [ObservableProperty]
    private Platform _platform;

    [ObservableProperty]
    private string _mediaType;

    [ObservableProperty]
    private string _content;

    [ObservableProperty]
    private string _noteText;

    [ObservableProperty]
    private bool _isNotePaneOpen;

    [ObservableProperty]
    private int _notePaneIndex;

    private string _id;

    public ArticleDetailViewModel()
    {
    }

    [RelayCommand]
    private void AddNote()
    {
        // TODO: Do something...
    }

    public void OnNavigatedTo(object parameter)
    {
        if (parameter is ArticleData article)
        {
            Title = article.Title;
            Time = article.Time;
            Topic = article.Topic;
            Platform = article.PlatformMapped;
            MediaType = article.MediaTypeMapped.ToString("G");
            Content = article.Content;
            _id = article.Id;
        }
    }

    public void OnNavigatedFrom()
    {

    }
}
