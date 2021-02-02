using System.Threading.Tasks;

namespace Front.Services.ViewModels
{
    internal sealed class MainLayoutComponent :
        ObservableItem,
        IMainLayoutComponent
    {
        public async Task Compose()
        {
            await Task.CompletedTask;
        }
    }
}