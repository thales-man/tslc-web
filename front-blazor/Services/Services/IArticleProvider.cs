using System.Threading.Tasks;
using Front.Services.Models;
using Tiny.Framework.Registration;

namespace Front.Services.Services
{
    public interface IArticleProvider :
        ISupportServiceRegistration
    {
        Task<ICatalogue> GetCatalogue();

        Task<string> GetArticleContent(string path);
    }
}