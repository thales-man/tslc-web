using System;
using System.Linq;
using System.Threading.Tasks;
using Front.Services.Models;
using Front.Services.Services;
using Tiny.Framework.Utility;

namespace Front.Services.ViewModels
{
    internal sealed class ContentAreaComponent :
        ObservableItem,
        IContentAreaComponent
    {
        public ContentAreaComponent(
            IArticleProvider articles,
            ICatalogueFilter filter)
        {
            It.IsNull(articles)
                .AsGuard<ArgumentNullException>(nameof(articles));
            It.IsNull(filter)
                .AsGuard<ArgumentNullException>(nameof(filter));

            Articles = articles;
            Filter = filter;
        }

        public IArticleProvider Articles { get; set; }

        public ICatalogueFilter Filter { get; set; }

        public IPostedArticle PostedArticle { get; set; }

        private string _articleContent;
        public string ArticleContent
        {
            get => _articleContent;
            set => SetPropertyValue(ref _articleContent, value);
        }

        public async Task Compose()
        {
            PostedArticle = Filter.DefaultArticle();
            await Task.CompletedTask;
        }

        public async Task LoadContent(string activatedRoute)
        {
            var sections = activatedRoute.Split("/");
            var catalogue = await Articles.GetCatalogue();
            var candidate = await Filter.FindArticleBy(sections.LastOrDefault(), catalogue);

            if (It.Has(candidate.Alias))
            {
                candidate = await Filter.FindArticleBy(candidate.Alias, catalogue);
            }

            PostedArticle = candidate;
            ArticleContent = await Articles.GetArticleContent(PostedArticle.Path);
        }
    }
}