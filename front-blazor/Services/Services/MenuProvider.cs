using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Front.Services.Models;
using Tiny.Framework.Utility;

namespace Front.Services.Services
{
    internal sealed class MenuProvider :
        IMenuProvider
    {
        public MenuProvider(ICatalogueFilter filter)
        {
            It.IsNull(filter)
                .AsGuard<ArgumentNullException>(nameof(filter));

            Filter = filter;
        }

        public ICatalogueFilter Filter { get; set; }

        public IMenuNode CreateBranch(string name)
        {
            return new MenuNode
            {
                Name = name
            };
        }

        public async Task<IMenuNode> GetPagesMenu(string subjectTitle, ICatalogue fromCatalogue) =>
            await GetSimpleMenu(subjectTitle, MenuCategories.Pages, fromCatalogue);

        public async Task<IMenuNode> GetExternalMenu(string subjectTitle, ICatalogue fromCatalogue) =>
            await GetSimpleMenu(subjectTitle, MenuCategories.External, fromCatalogue);

        public async Task<IMenuNode> GetArticlesMenu(string subjectTitle, ICatalogue fromCatalogue)
        {
            var menu = CreateBranch(subjectTitle);
            var yearBranch = default(IMenuNode);
            var monthBranch = default(IMenuNode);

            (await GetFilteredArticles(MenuCategories.Articles, fromCatalogue))
                .OrderByDescending(x => x.PublicationDate)
                .AsSafeReadOnlyList()
                .ForEach(post =>
                {
                    var node = CreateLeaf(post);

                    yearBranch = menu.Children.FirstOrDefault(x => x.Name == node.Year);
                    if (yearBranch is null)
                    {
                        yearBranch = CreateBranch(node.Year);
                        menu.Children.Add(yearBranch);
                    }

                    monthBranch = yearBranch.Children.FirstOrDefault(x => x.Name == node.Month);
                    if (monthBranch is null)
                    {
                        monthBranch = CreateBranch(node.Month);
                        yearBranch.Children.Add(monthBranch);
                    }

                    monthBranch.AddNode(node);
                    yearBranch.IncrementCount();
                });

            return menu;
        }

        internal IMenuNode CreateLeaf(IPostedArticle article)
        {
            return new MenuNode
            {
                Name = article.Title,
                Topic = article.Topic != MenuCategories.External ? article.Topic : article.Path,
                Year = article.Year,
                Month = article.Month,
                Article = article.Article
            };
        }

        internal async Task<IEnumerable<IPostedArticle>> GetFilteredArticles(string filter, ICatalogue fromCatalogue) =>
            await Filter.FindArticles(filter, fromCatalogue);

        internal async Task<IMenuNode> GetSimpleMenu(string subjectTitle, string filter, ICatalogue fromCatalogue)
        {
            var menu = CreateBranch(subjectTitle);

            (await GetFilteredArticles(filter, fromCatalogue))
                .AsSafeReadOnlyList()
                .ForEach(post =>
                {
                    var node = CreateLeaf(post);
                    menu.Children.Add(node);
                });

            return menu;
        }
    }
}