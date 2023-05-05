using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.WinUI.UI;
using IRSSClientDesktop.Contracts.ViewModels;
using IRSSClientDesktop.Core.Contracts.Services;
using IRSSClientDesktop.Core.Models;
using static System.Net.Mime.MediaTypeNames;

namespace IRSSClientDesktop.ViewModels;

public partial class FavoriteViewModel : ObservableRecipient
{
    private Predicate<FavoriteData> _typePredicate = _ => true;

    private Predicate<FavoriteData> _textPredicate = _ => true;

    private ObservableCollection<FavoriteData> _favorites;

    public AdvancedCollectionView FilteredFavorites
    {
        get;
        set;
    }

    [ObservableProperty]
    private string _searchText;

    [ObservableProperty]
    private int _selectedIndex;

    public FavoriteViewModel()
    {
        _favorites = new ObservableCollection<FavoriteData>()
        {
            new FavoriteData()
            {
                Time = new DateTime(2019, 12, 1),
                Source = "Bilibili",
                Content = "一些视频总结",
                Type = FavoriteType.Article,
                Id = "1"
            },
            new FavoriteData()
            {
                Time = new DateTime(2018,12,8),
                Source = "离散cp2022@whu",
                Content = "上交离散数学的作业",
                Type = FavoriteType.Message,
                Id = "1"
            }
        };

        FilteredFavorites = new AdvancedCollectionView(_favorites, true);

        FilteredFavorites.SortDescriptions.Add(new SortDescription("Time", SortDirection.Descending));
        FilteredFavorites.SortDescriptions.Add(new SortDescription("Type", SortDirection.Ascending));
        FilteredFavorites.SortDescriptions.Add(new SortDescription("Content", SortDirection.Ascending));
    }

    partial void OnSelectedIndexChanged(int value)
    {
        _typePredicate = value switch
        {
            0 => _ => true,
            1 => favorite => favorite.Type == FavoriteType.Message,
            2 => favorite => favorite.Type == FavoriteType.Article,
            _ => throw new ArgumentOutOfRangeException()
        };
        
        FilteredFavorites.Filter = (obj) => obj is FavoriteData favorite && _typePredicate.Invoke(favorite) && _textPredicate.Invoke(favorite);
        FilteredFavorites.RefreshFilter();
    }

    partial void OnSearchTextChanged(string value)
    {
        _textPredicate = value switch
        {
            null or "" => _ => true,
            _ => favorite => favorite.Content.ToLower().Contains(value.ToLower())
        };
        
        FilteredFavorites.Filter = (obj) => obj is FavoriteData favorite && _typePredicate.Invoke(favorite) && _textPredicate.Invoke(favorite);
        FilteredFavorites.RefreshFilter();
    }
}
