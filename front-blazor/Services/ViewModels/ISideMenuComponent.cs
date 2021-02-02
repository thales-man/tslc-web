using System.ComponentModel;
using Front.Services.Models;
using Tiny.Framework.Registration;

namespace Front.Services.ViewModels
{
    public interface ISideMenuComponent :
        INotifyPropertyChanged,
        ISupportServiceRegistration,
        IComposable
    {
        IMenuNode HomeMenu { get; }

        IMenuNode ExternalMenu { get; }

        IMenuNode ArticleMenu { get; }
    }
}
