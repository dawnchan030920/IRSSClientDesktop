using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSSClientDesktop.Core.Contracts.OrmModel;
using IRSSClientDesktop.Core.Models;
using Refit;

namespace IRSSClientDesktop.Core.Contracts.Services;
public interface IIRSSHttpService
{
    #region Auth

    [Post("/auth/register")]
    Task<RegisterResponseOrm> RegisterUser([Body] AuthUserRequestOrm userRequest);

    [Post("/auth/login")]
    Task<LoginResponseOrm> LoginUser([Body] AuthUserRequestOrm userRequest);

    [Headers("Authorization: Bearer")]
    [Post("/auth")]
    Task<CheckAuthResponseOrm> CheckAuth();

    #endregion

    #region Account

    [Headers("Authorization: Bearer")]
    [Get("/account")]
    Task<AccountGetRequestOrm> GetAccounts();

    [Headers("Authorization: Bearer")]
    [Post("/account")]
    Task<AccountAddResponseOrm> AddAccount([Body] AccountAddRequestOrm accountAddRequest);

    [Delete("/account")]
    Task<AccountDeleteResponseOrm> DeleteAccount([Body] AccountDeleteRequestOrm accountDeleteRequest);

    #endregion

    #region Information Management

    [Get("/info/message/topic")]
    Task<MessageTopicGetResponseOrm> GetMessageTopics();

    [Post("/info/message/topic")]
    Task<MessageTopicResponseWithStatusOrm> AddMessageTopics([Body] MessageTopicAddRequestOrm messageTopicAddRequest);

    [Delete("/info/message/topic")]
    Task<MessageTopicResponseWithStatusOrm> DeleteMessageTopics(
        [Body] MessageTopicDeleteRequestOrm messageTopicDeleteRequest);

    [Post("/info/subscription/author/{platform}")]
    Task<AuthorListResponseOrm> SearchAuthor([Body] AuthorSearchRequestOrm authorSearchRequest, [AliasAs("platform")] string platform);

    [Get("/info/subscription/author/{platform}/subscribed")]
    Task<AuthorListResponseOrm> GetSubscribedAuthors([AliasAs("platform")] string platform);

    [Post("/info/subscription/author/{platform}/subscribed")]
    Task<AuthorListResponseOrm> SubscribeAuthor([Body] AuthorWithUsernameId author, [AliasAs("platform")] string platform);

    [Delete("/info/subscription/author/{platform}/subscribed")]
    Task<AuthorListResponseOrm> UnsubscribeAuthor([Body] AuthorDeleteRequestOrm authorDeleteRequest,
        [AliasAs("platform")] string platform);

    [Get("/info/article/topic/selected")]
    Task<ArticleTopicListOrm> GetSelectedArticles();

    [Post("/info/article/topic/selected")]
    Task<ArticleTopicListOrm> SetSelectedArticles([Body] ArticleTopicListOrm selectedArticles);

    [Post("/info/answer")]
    Task<AnswerResponseOrm> GetAnswer([Body] AnswerRequestOrm answerRequest);

    #endregion

    #region User Content

    [Get("/user/note")]
    Task<NoteListOrm> GetNotes();

    [Post("/user/note")]
    Task<NoteListOrm> SetNotes([Body] NoteOrm note);

    [Delete("/user/note")]
    Task<NoteListOrm> DeleteNotes([Body] NoteDeleteRequestOrm noteDeleteRequest);

    [Get("/user/favorite")]
    Task<FavoriteListOrm> GetFavorites();

    [Post("/user/favorite")]
    Task<FavoriteListOrm> SetFavorites([Body] FavoriteOrm favorite);

    [Delete("/user/favorite")]
    Task<FavoriteListOrm> DeleteFavorites([Body] FavoriteDeleteRequestOrm favoriteDeleteRequest);

    #endregion
}
