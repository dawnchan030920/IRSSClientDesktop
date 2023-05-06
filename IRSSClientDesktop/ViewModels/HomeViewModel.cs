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

        Username = "Dawn Chan";

        Articles = new ObservableCollection<ArticleData>()
        {
            new ArticleData()
            {
                Content = "A black dog jumps over a brown fox.a black dog jumps over a brown fox.",
                Id = "1",
                IsFavorite = false,
                MediaType = "words",
                Platform = "zhihu",
                Time = new DateTime(2022, 1, 1),
                Title = "Forest Story",
                Topic = "genshin impact"
            },
            new ArticleData()
            {
                Content = "There are a lot of students here in the classroom.",
                Id = "1",
                IsFavorite = false,
                MediaType = "words",
                Platform = "wechat",
                Time = new DateTime(2022, 1, 1),
                Title = "Taking Classes",
                Topic = "Wuhan University"
            },
            new ArticleData()
            {
                Content = "Sakura blossoms and it's really amazing.",
                Id = "1",
                IsFavorite = false,
                MediaType = "video",
                Platform = "bilibili",
                Time = new DateTime(2022, 1, 1),
                Title = "Sakura",
                Topic = "Wuhan University"
            },
            new ArticleData()
            {
                Content = "https://www.bilibili.com",
                Id = "1",
                IsFavorite = false,
                MediaType = "video",
                Platform = "bilibili",
                Time = new DateTime(2022, 1, 1),
                Title = "想不到你是这样的三月七",
                Topic = "星穹铁道"
            },
        };
    }
}
