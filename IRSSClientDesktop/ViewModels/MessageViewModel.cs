using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.WinUI.UI;
using IRSSClientDesktop.Core.Models;

namespace IRSSClientDesktop.ViewModels;

public partial class MessageViewModel : ObservableRecipient
{
    private ObservableCollection<MessageTopicNotificationData> _topicNotifications;

    public ObservableCollection<MessageSummaryData> Summaries
    {
        get;
        set;
    }

    public ObservableCollection<MessageMentionNotificationData> MentionNotifications
    {
        get;
        set;
    }

    [ObservableProperty] private int _selectedIndex;

    public ObservableCollection<string> Topics
    {
        get;
        set;
    }

    public AdvancedCollectionView FilteredTopicNotifications
    {
        get;
        set;
    }
    
    [ObservableProperty]
    private string? _filterTopic;

    [RelayCommand]
    private void ClearFilterTopics()
    {
        FilterTopic = null;
    }

    public MessageViewModel()
    {
        _topicNotifications = new ObservableCollection<MessageTopicNotificationData>()
        {
            new MessageTopicNotificationData()
            {
                Content = "Shadow dots strawberry Pac-Man Midway chaser Pinky kill screen.",
                Id = "1",
                OriginalContent = "She learned that water bottles are no longer just to hold liquid, but they're also status symbols. She learned that water bottles are no longer just to hold liquid, but they're also status symbols. She learned that water bottles are no longer just to hold liquid, but they're also status symbols. She learned that water bottles are no longer just to hold liquid, but they're also status symbols.",
                Time = new DateTime(2022,5,1),
                Topic = "WHU"
            },
            new MessageTopicNotificationData()
            {
                Content = "React?",
                Id = "2",
                OriginalContent = "Reactttttttttt?",
                Time = new DateTime(1999,1,1),
                Topic = "React"
            }
        };
        Summaries = new ObservableCollection<MessageSummaryData>()
        {
            new()
            {
                Group = "软创群",
                Summary = "我说：大概能做完\n他说：不一定",
                OriginalContent = "lsm：asudhiwe\n爱上丢货：阿斯u护额我iu然后"
            }
        };
        MentionNotifications = new ObservableCollection<MessageMentionNotificationData>()
        {
            new()
            {
                Content = "上交自科论文",
                OriginalContent = "请大家上交自科论文捏",
                Time = new DateTime(2022, 3, 1),
                Username = "1270292123",
                Id = "3"
            }
        };
        FilteredTopicNotifications = new AdvancedCollectionView(_topicNotifications, true);
        FilteredTopicNotifications.SortDescriptions.Add(new SortDescription("Time", SortDirection.Descending));
        Topics = new ObservableCollection<string>()
        {
            "WHU", "CS", "React", "WinUI3"
        };
    }

    partial void OnFilterTopicChanged(string? value)
    {
        UpdateFilter(value);
    }

    private void UpdateFilter(string? value)
    {
        FilteredTopicNotifications.Filter = obj => value == null || ((MessageTopicNotificationData)obj).Topic == value;
    }
}
