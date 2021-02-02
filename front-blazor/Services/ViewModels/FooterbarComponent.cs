using System.Threading.Tasks;

namespace Front.Services.ViewModels
{
    internal sealed class FooterbarComponent :
        ObservableItem,
        IFooterbarComponent
    {
        public async Task Compose()
        {
            await Task.CompletedTask;
        }
    }
}
