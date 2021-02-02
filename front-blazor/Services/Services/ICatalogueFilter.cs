using System.Collections.Generic;
using System.Threading.Tasks;
using Front.Services.Models;
using Tiny.Framework.Registration;

namespace Front.Services.Services
{
    public interface ICatalogueFilter :
        ISupportServiceRegistration
    {
        IPostedArticle DefaultArticle();

        Task<IPostedArticle> FindArticle(string withTopic, string inYear, string andMonth, string andName, ICatalogue fromCatalogue);

        Task<IPostedArticle> FindArticleBy(string id, ICatalogue fromCatalogue);

        Task<IEnumerable<IPostedArticle>> FindArticles(string usingFilter, ICatalogue fromCatalogue);
    }
}