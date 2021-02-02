using System.Net.Http;
using System.Threading.Tasks;
using Front.Services.Models;
using Newtonsoft.Json;

namespace Front.Services.Services
{
    internal sealed class ArticleProvider :
        IArticleProvider
    {
        private const string ArticlesUrl = "articles/catalogue";
        private HttpClient _client;

        public ArticleProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<ICatalogue> GetCatalogue()
        {
            var result = await _client.GetStringAsync(ArticlesUrl);

            return JsonConvert.DeserializeObject<Catalogue>(result);
        }

        public async Task<string> GetArticleContent(string path)=>
            await _client.GetStringAsync(path);
    }
}