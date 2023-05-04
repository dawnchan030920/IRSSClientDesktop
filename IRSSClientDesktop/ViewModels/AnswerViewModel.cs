using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IRSSClientDesktop.Core.Models;

namespace IRSSClientDesktop.ViewModels;

public partial class AnswerViewModel : ObservableRecipient
{
    public ObservableCollection<AnswerData> Answers
    {
        get;
        set;
    }

    [ObservableProperty]
    private string _questionText;

    [RelayCommand]
    private void SearchQuestion()
    {
        Answers.RemoveAt(0);
        // TODO: Search the question.
    }

    public AnswerViewModel()
    {
        Answers = new ObservableCollection<AnswerData>()
        {
            new AnswerData()
            {
                Summary = "Join more activities",
                References = new List<AnswerReference>()
                {
                    new AnswerReference()
                    {
                        Title = "How will?",
                        Content = "This is the reason: ..."
                    }
                }
            },
            new AnswerData()
            {
                Summary = "Find a partner",
                References = new List<AnswerReference>()
                {
                    new AnswerReference()
                    {
                        Title = "Partner Psychology",
                        Content = "Study shows that..."
                    },
                    new AnswerReference()
                    {
                        Title = "Why a partner?",
                        Content = "Partner helps to ..."
                    }
                }
            },
            new AnswerData()
            {
                Summary = "Join more activitiesJoin more activitiesJoin more activitiesJoin more activitiesJoin more activitiesJoin more activitiesJoin more activitiesJoin more activitiesJoin more activitiesJoin more activitiesJoin more activitiesJoin more activitiesJoin more activitiesJoin more activitiesJoin more activitiesJoin more activitiesJoin more activitiesJoin more activitiesJoin more activitiesJoin more activities",
                References = new List<AnswerReference>()
                {
                    new AnswerReference()
                    {
                        Title = "How will?",
                        Content = "This is the reason: ..."
                    }
                }
            },
            new AnswerData()
            {
                Summary = "Join more activities",
                References = new List<AnswerReference>()
                {
                    new AnswerReference()
                    {
                        Title = "How will?",
                        Content = "This is the reason: ..."
                    }
                }
            },
            new AnswerData()
            {
                Summary = "Join more activities",
                References = new List<AnswerReference>()
                {
                    new AnswerReference()
                    {
                        Title = "How will?",
                        Content = "This is the reason: ..."
                    }
                }
            },
            new AnswerData()
            {
                Summary = "Join more activities",
                References = new List<AnswerReference>()
                {
                    new AnswerReference()
                    {
                        Title = "How will?",
                        Content = "This is the reason: ..."
                    }
                }
            },
            new AnswerData()
            {
                Summary = "Join more activities",
                References = new List<AnswerReference>()
                {
                    new AnswerReference()
                    {
                        Title = "How will?",
                        Content = "This is the reason: ..."
                    }
                }
            },
            new AnswerData()
            {
                Summary = "Join more activities",
                References = new List<AnswerReference>()
                {
                    new AnswerReference()
                    {
                        Title = "How will?",
                        Content = "This is the reason: ..."
                    }
                }
            },
        };
    }
}
