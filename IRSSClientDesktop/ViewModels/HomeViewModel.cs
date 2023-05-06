using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IRSSClientDesktop.Contracts.Services;
using IRSSClientDesktop.Core.Models;

namespace IRSSClientDesktop.ViewModels;

public partial class HomeViewModel : ObservableRecipient
{
    INavigationService _navigationService;

    [ObservableProperty]
    private bool _isLoggedIn;

    [ObservableProperty]
    private string _username;

    public ObservableCollection<ArticleData> Articles
    {
        get;
        set;
    }

    public ObservableCollection<MessageTopicNotificationData> MessageTopicNotifications
    {
        get;
        set;
    }

    public ObservableCollection<MessageMentionNotificationData> MessageMentionNotifications
    {
        get;
        set;
    }

    public ObservableCollection<MessageSummaryData> MessageSummaries
    {
        get;
        set;
    }

    [RelayCommand]
    private void NavigateTo(PagekeyDataPair pair)
    {
        _navigationService.NavigateTo(pair.Key, pair.Data);
    }

    public HomeViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        IsLoggedIn = true;

        Articles = new ObservableCollection<ArticleData>()
        {
            new ArticleData()
            {
                Content = "a black dog jumps over a brown fox.a black dog jumps over a brown fox.a black dog jumps over a brown fox.a black dog jumps over a brown fox.",
                Id = "1",
                IsFavorite = false,
                MediaType = "video",
                Platform = "bilibili",
                Time = new DateTime(2022, 1, 1),
                Title = "This is the test title",
                Topic = "op"
            },
            new ArticleData()
            {
                Content = "a",
                Id = "1",
                IsFavorite = false,
                MediaType = "video",
                Platform = "bilibili",
                Time = new DateTime(2022, 1, 1),
                Title = "T",
                Topic = "op"
            },
            new ArticleData()
            {
                Content = "a",
                Id = "1",
                IsFavorite = false,
                MediaType = "video",
                Platform = "bilibili",
                Time = new DateTime(2022, 1, 1),
                Title = "T",
                Topic = "op"
            },
            new ArticleData()
            {
                Content = "a",
                Id = "1",
                IsFavorite = false,
                MediaType = "video",
                Platform = "bilibili",
                Time = new DateTime(2022, 1, 1),
                Title = "T",
                Topic = "op"
            },
        };
    }
}
