using System.Threading.Tasks;
using Front.Services.Models;
using Tiny.Framework.Registration;

namespace Front.Services.Services
{
    public interface IMenuProvider :
        ISupportServiceRegistration
    {
        IMenuNode CreateBranch(string name);

        Task<IMenuNode> GetArticlesMenu(string subjectTitle, ICatalogue fromCatalogue);

        Task<IMenuNode> GetExternalMenu(string subjectTitle, ICatalogue fromCatalogue);

        Task<IMenuNode> GetPagesMenu(string subjectTitle, ICatalogue fromCatalogue);
    }
}