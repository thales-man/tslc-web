using System.ComponentModel;
using Tiny.Framework.Registration;

namespace Front.Services.ViewModels
{
    public interface IFooterbarComponent :
        INotifyPropertyChanged,
        ISupportServiceRegistration,
        IComposable
    {

    }
}
