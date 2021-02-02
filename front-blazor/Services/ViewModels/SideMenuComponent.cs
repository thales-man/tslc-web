using System;
using System.Threading.Tasks;
using Front.Services.Models;
using Front.Services.Services;
using Tiny.Framework.Utility;

namespace Front.Services.ViewModels
{
    internal sealed class SideMenuComponent :
        ObservableItem,
        ISideMenuComponent
    {
        public SideMenuComponent(
            IArticleProvider articles,
            IMenuProvider menus)
        {
            Articles = articles;
            Menus = menus;
        }

        public IArticleProvider Articles { get; set; }

        public IMenuProvider Menus { get; set; }

        public IMenuNode HomeMenu { get; set; }

        public IMenuNode ExternalMenu { get; set; }

        public IMenuNode ArticleMenu { get; set; }

        public async Task Compose()
        {
            // don't comment out the next three lines
            // because it goes into a tight unforgiving cycle (for some reason...)
            HomeMenu = Menus.CreateBranch(MenuHeaders.Pages);
            ExternalMenu = Menus.CreateBranch(MenuHeaders.External);
            ArticleMenu = Menus.CreateBranch(MenuHeaders.Articles);

            var catalogue = await Articles.GetCatalogue();

            It.IsNull(catalogue)
                .AsGuard<ArgumentNullException>(nameof(catalogue));

            HomeMenu = await Menus.GetPagesMenu(MenuHeaders.Pages, catalogue);
            ExternalMenu = await Menus.GetExternalMenu(MenuHeaders.External, catalogue);
            ArticleMenu = await Menus.GetArticlesMenu(MenuHeaders.Articles, catalogue);

            It.IsEmpty(HomeMenu.Children)
                .AsGuard<ArgumentException>(nameof(HomeMenu.Children));
        }
    }
}
