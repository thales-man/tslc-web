using System.Threading.Tasks;

namespace Front.Services.ViewModels
{
    internal sealed class HeaderbarComponent :
        ObservableItem,
        IHeaderbarComponent
    {
        public async Task Compose()
        {
            await Task.CompletedTask;
        }
    }
}
