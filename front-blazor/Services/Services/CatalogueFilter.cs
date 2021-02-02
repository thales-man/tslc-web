using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Front.Services.Models;

namespace Front.Services.Services
{
    internal sealed class CatalogueFilter :
        ICatalogueFilter
    {
        public IPostedArticle DefaultArticle()
        {
            return new PostedArticle
            {
                Article = "loading-content",
                Title = "loading content",
                Topic = "posts",
                PublicationDate = DateTime.Today,
                Path = "/assets/nocontent.md"
            };
        }

        public async Task<IEnumerable<IPostedArticle>> FindArticles(string usingFilter, ICatalogue fromCatalogue) =>
            await Task.FromResult(fromCatalogue.Articles.Where(x => x.Topic == usingFilter));

        public async Task<IPostedArticle> FindArticleBy(string id, ICatalogue fromCatalogue) =>
            await Task.FromResult(fromCatalogue.Articles.FirstOrDefault(post => post.Article == id));

        public async Task<IPostedArticle> FindArticle(string withTopic, string inYear, string andMonth, string andName, ICatalogue fromCatalogue) =>
            await Task.FromResult(fromCatalogue.Articles.FirstOrDefault(post =>
                post.Topic == withTopic
                && post.Year == inYear
                && post.Month == andMonth
                && post.Article == andName));
    }
}