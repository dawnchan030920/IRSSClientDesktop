using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.WinUI.UI;
using IRSSClientDesktop.Contracts.Services;
using IRSSClientDesktop.Core.Models;
using Microsoft.UI.Xaml.Controls;

namespace IRSSClientDesktop.ViewModels;

public partial class ArticleViewModel : ObservableRecipient
{
    private Predicate<ArticleData> _isTopicPredicate = _ => true;

    private Predicate<ArticleData> _containTextPredicate = _ => true;

    private List<string> _cachedTopics;

    [ObservableProperty]
    private int _articleCount;

    [ObservableProperty]
    private bool _isTopicPanelOpen;

    [ObservableProperty]
    private bool _isFilterOpen;

    [ObservableProperty]
    private string _newTopicText;

    [ObservableProperty]
    private string? _filterTopic;

    [ObservableProperty]
    private string? _filterText;

    private ObservableCollection<ArticleData> _articles;
    
    public AdvancedCollectionView FilteredArticles
    {
        get;
        set;
    }

    public ObservableCollection<string> FilterTopics
    {
        get;
        set;
    }

    public ObservableCollection<string> PanelTopics
    {
        get;
        set;
    }

    public INavigationService NavigationService
    {
        get;
    }

    [RelayCommand]
    private void ClearFilterTopic()
    {
        FilterTopic = null;
    }

    [RelayCommand]
    private void AddNewTopic()
    {
        if (!string.IsNullOrEmpty(NewTopicText))
        {
            PanelTopics.Add(NewTopicText);
            NewTopicText = string.Empty;
        }
    }

    [RelayCommand]
    private void Undo()
    {
        PanelTopics.Clear();
        _cachedTopics.ForEach(topic => PanelTopics.Add(topic));
    }

    [RelayCommand]
    private void Upload()
    {

    }

    [RelayCommand]
    private void NavigateToArticleDetail(object item)
    {
        if (item is ArticleData article)
        {
            NavigationService.NavigateTo(typeof(ArticleDetailViewModel).FullName!, article);
        }
    }

    public ArticleViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;

        _cachedTopics = new List<string>();

        PanelTopics = new ObservableCollection<string>()
        {
            "Wuhan University", "Computer Science", "Abstracitoinism"
        };

        _cachedTopics = new List<string>()
        {
            "Wuhan University", "Computer Science", "Abstracitoinism"
        };

        FilterTopics = new ObservableCollection<string>(_cachedTopics);

        _articles = new ObservableCollection<ArticleData>()
        {
            new()
            {
                Title = "How will WinUI3 help",
                Content = "This is the report about how will winui3 hel",
                MediaType = "words",
                Platform = "zhihu",
                Time = new DateTime(2022, 5, 4),
                Id = "1",
                Topic = "Computer Science"
            },
            new()
            {
                Title = "Microsoft Official",
                Content = "https://www.microsoft.com",
                MediaType = "video",
                Platform = "bilibili",
                Time = new DateTime(2019,1,4),
                Id = "2",
                Topic = "Company"
            },
            new()
            {
                Title = "A Very Strange Bug",
                Content = "This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug.This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug.This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug.This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug.This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug.This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug.This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug.This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug.This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug.This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug.This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug.This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug. This is a very strange bug.",
                MediaType = "words",
                Platform = "wechat",
                Time = new DateTime(2022, 5, 4),
                Id = "3",
                Topic = "Wuhan University"
            },
            new()
            {
                Title = "Baidu Official",
                Content = "https://www.baidu.com",
                MediaType = "video",
                Platform = "bilibili",
                Time = new DateTime(2019,1,4),
                Id = "4",
                Topic = "Company"
            },
        };

        FilteredArticles = new AdvancedCollectionView(_articles, true);

        FilteredArticles.SortDescriptions.Add(new SortDescription("Time", SortDirection.Descending));
        FilteredArticles.SortDescriptions.Add(new SortDescription("Title", SortDirection.Ascending));

        ArticleCount = _articles.Count;
    }
    
    partial void OnFilterTopicChanged(string? value)
    {
        _isTopicPredicate = article => value == null || article.Topic == value;

        FilteredArticles.Filter = o => o is ArticleData article && _isTopicPredicate.Invoke(article) && _containTextPredicate.Invoke(article);
    }

    partial void OnFilterTextChanged(string? value)
    {
        _containTextPredicate = article => value == null || article.Title.ToLower().Contains(value.ToLower()) || article.Content.ToLower().Contains(value.ToLower());

        FilteredArticles.Filter = o => o is ArticleData article && _isTopicPredicate.Invoke(article) && _containTextPredicate.Invoke(article);
    }
}
