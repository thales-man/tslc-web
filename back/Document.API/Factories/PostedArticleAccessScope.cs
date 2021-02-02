using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Document.API.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Tiny.Framework.Data.Configuration;
using Tiny.Framework.Data.Factories;
using Tiny.Framework.Utility;

namespace Document.API.Factories
{
    /// <summary>
    /// document detail access scope.
    /// </summary>
    internal sealed class PostedArticleAccessScope :
        DataAccessScope,
        IScopeAccessToPostedArticles
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostedArticleAccessScope"/> class.
        /// </summary>
        /// <param name="configuration">the configuration.</param>
        public PostedArticleAccessScope(IConfigureContextScope configuration)
            : base(configuration)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// gets or sets the articles.
        /// </summary>
        public DbSet<PostedArticle> Articles { get; set; }

        /// <inheritdoc/>
        public async Task<ICatalogue> GetDocumentCatalogue()
        {
            var articles = await Articles.ToArrayAsync();
            return new Catalogue { Articles = articles };
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (File.Exists("articles.json"))
            {
                ColorConsole.Startup("initialising catalogue");

                var fileContent = File.OpenText("articles.json");
                var articles = JsonConvert.DeserializeObject<List<PostedArticle>>(fileContent.ReadToEnd());

                modelBuilder.Entity<PostedArticle>().HasData(articles);

                File.Delete("articles.json");
            }
        }
    }
}
