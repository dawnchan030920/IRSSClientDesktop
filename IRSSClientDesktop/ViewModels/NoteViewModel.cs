using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IRSSClientDesktop.Contracts.Services;
using IRSSClientDesktop.Contracts.ViewModels;
using IRSSClientDesktop.Core.Contracts.Services;
using IRSSClientDesktop.Core.Models;
using IRSSClientDesktop.ObservableModels;

namespace IRSSClientDesktop.ViewModels;

public partial class NoteViewModel : ObservableRecipient
{
    private INavigationService _navigationService;
    
    public ObservableCollection<ObservableNoteData> Notes
    {
        get;
        set;
    }

    [ObservableProperty]
    private ObservableNoteData _selectedNode;

    [RelayCommand]
    private void OpenArticle()
    {
        // TODO: Use content management service.
        _navigationService.NavigateTo(typeof(ArticleDetailViewModel).FullName!, new ArticleData()
        {
            Title = SelectedNode.ArticleTitle,
            Content = "Sample Content",
            MediaType = "video",
            Id = SelectedNode.Id,
            Platform = "wechat",
            Time = new DateTime(2019,12,3),
            Topic = "Test"
        });
    }

    [RelayCommand]
    private void UploadNote()
    {
        // TODO: Do something.
    }

    public NoteViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        Notes = new ObservableCollection<ObservableNoteData>()
        {
            new(new()
            {
                Id = "1",
                Content = "# This is the Header",
                Time = new DateTime(2022, 1, 2)
            }),
            new(new()
            {
                Id = "2",
                Content = "# This is the Another Header",
                Time = new DateTime(2022, 1, 2)
            }),
            new(new()
            {
                Id = "3",
                Content = "# This is the Header",
                Time = new DateTime(2022, 1, 2)
            }),
            new(new()
            {
                Id = "4",
                Content = "# This is the Header",
                Time = new DateTime(2022, 1, 2)
            }),
            new(new()
            {
                Id = "5",
                Content = "# This is the Header",
                Time = new DateTime(2022, 1, 2)
            }),
            new(new()
            {
                Id = "6",
                Content = "# This is the Header",
                Time = new DateTime(2022, 1, 2)
            }),
            new(new()
            {
                Id = "7",
                Content = "# This is the Header",
                Time = new DateTime(2022, 1, 2)
            }),
            new(new()
            {
                Id = "8",
                Content = "# This is the Header",
                Time = new DateTime(2022, 1, 2)
            }),
            new(new()
            {
                Id = "9",
                Content = "# This is the Header",
                Time = new DateTime(2022, 1, 2)
            }),
            new(new()
            {
                Id = "10",
                Content = "# This is the Header",
                Time = new DateTime(2022, 1, 2)
            })
        };
    }
}
