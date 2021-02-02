using Tiny.Framework.Data.Factories;

namespace Document.API.Factories
{
    /// <summary>
    /// i create posted article access scopes.
    /// </summary>
    public interface ICreatePostedArticleAccessScopes :
        ICreateAccessScopes<IScopeAccessToPostedArticles>
    {
    }
}
