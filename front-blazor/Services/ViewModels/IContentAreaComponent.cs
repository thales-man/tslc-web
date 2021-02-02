using System.ComponentModel;
using System.Threading.Tasks;
using Front.Services.Models;
using Tiny.Framework.Registration;

namespace Front.Services.ViewModels
{
    public interface IContentAreaComponent :
        INotifyPropertyChanged,
        ISupportServiceRegistration,
        IComposable
    {
        IPostedArticle PostedArticle { get; }
        string ArticleContent { get; set; }

        Task LoadContent(string activatedRoute);
    }
}