using CommunityToolkit.Mvvm.ComponentModel;

using IRSSClientDesktop.Contracts.Services;
using IRSSClientDesktop.ViewModels;
using IRSSClientDesktop.Views;

using Microsoft.UI.Xaml.Controls;

namespace IRSSClientDesktop.Services;

public class PageService : IPageService
{
    private readonly Dictionary<string, Type> _pages = new();

    public PageService()
    {
        Configure<HomeViewModel, HomePage>();
        Configure<SettingsViewModel, SettingsPage>();
        Configure<SourceViewModel, SourcePage>();
        Configure<MessageViewModel, MessagePage>();
        Configure<ArticleViewModel, ArticlePage>();
        Configure<AnswerViewModel, AnswerPage>();
        Configure<FavoriteViewModel, FavoritePage>();
        Configure<NoteViewModel, NotePage>();
        Configure<QQViewModel, QQPage>();
        Configure<WechatViewModel, WechatPage>();
        Configure<ZhihuViewModel, ZhihuPage>();
        Configure<BilibiliViewModel, BilibiliPage>();
        Configure<ArticleDetailViewModel, ArticleDetailPage>();
    }

    public Type GetPageType(string key)
    {
        Type? pageType;
        lock (_pages)
        {
            if (!_pages.TryGetValue(key, out pageType))
            {
                throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
            }
        }

        return pageType;
    }

    private void Configure<VM, V>()
        where VM : ObservableObject
        where V : Page
    {
        lock (_pages)
        {
            var key = typeof(VM).FullName!;
            if (_pages.ContainsKey(key))
            {
                throw new ArgumentException($"The key {key} is already configured in PageService");
            }

            var type = typeof(V);
            if (_pages.Any(p => p.Value == type))
            {
                throw new ArgumentException($"This type is already configured with key {_pages.First(p => p.Value == type).Key}");
            }

            _pages.Add(key, type);
        }
    }
}
