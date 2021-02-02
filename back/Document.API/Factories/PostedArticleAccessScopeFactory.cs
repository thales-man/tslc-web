using System;
using Document.API.Configuration;
using Tiny.Framework.Container;
using Tiny.Framework.Data.Configuration;
using Tiny.Framework.Data.Factories;
using Tiny.Framework.Utility;

namespace Document.API.Factories
{
    /// <summary>
    /// posted article access scope factory.
    /// </summary>
    internal sealed class PostedArticleAccessScopeFactory :
        ContextScopeFactory<PostedArticleAccessScope, IScopeAccessToPostedArticles>,
        ICreatePostedArticleAccessScopes
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostedArticleAccessScopeFactory"/> class.
        /// </summary>
        /// <param name="host">the host configuration.</param>
        /// <param name="configuration">the configuration.</param>
        public PostedArticleAccessScopeFactory(IHostConfiguration host, IConfigurePostedArticleAccessScope configuration)
            : base(configuration)
        {
            It.IsNull(host)
                .AsGuard<ArgumentNullException>(nameof(host));

            configuration.SetHostConfiguration(host);
        }

        /// <inheritdoc/>
        public override PostedArticleAccessScope CreateScope(IConfigureContextScope configureContext) =>
            new PostedArticleAccessScope(configureContext);
    }
}
