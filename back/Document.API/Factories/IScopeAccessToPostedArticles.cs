using System.Threading.Tasks;
using Document.API.Models;
using Tiny.Framework.Data.Factories;

namespace Document.API.Factories
{
    /// <summary>
    /// i scope access to posted articles.
    /// </summary>
    public interface IScopeAccessToPostedArticles :
        IScopeAccessToData
    {
        /// <summary>
        /// gets the catalogue.
        /// </summary>
        /// <returns>the catalgoue.</returns>
        Task<ICatalogue> GetDocumentCatalogue();
    }
}
