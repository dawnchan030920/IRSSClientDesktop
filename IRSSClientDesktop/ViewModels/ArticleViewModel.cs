using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace IRSSClientDesktop.ViewModels;

public partial class ArticleViewModel : ObservableRecipient
{
    private List<string> _cachedTopics;

    [ObservableProperty]
    private int _articleCount;

    [ObservableProperty]
    private bool _isTopicPanelOpen;

    [ObservableProperty]
    private string _newTopicText;

    public ObservableCollection<string> Topics
    {
        get;
        set;
    } = new();

    [RelayCommand]
    private void AddNewTopic()
    {
        if (!string.IsNullOrEmpty(NewTopicText))
        {
            Topics.Add(NewTopicText);
            NewTopicText = string.Empty;
        }
    }

    [RelayCommand]
    private void Undo()
    {
        Topics.Clear();
        _cachedTopics.ForEach(topic => Topics.Add(topic));
    }

    [RelayCommand]
    private void Upload()
    {

    }

    public ArticleViewModel()
    {
        _cachedTopics = new List<string>();
    }
}
