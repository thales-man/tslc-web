using System;
using System.IO;
using Document.API.Factories;
using Microsoft.EntityFrameworkCore;
using Tiny.Framework.Container;
using Tiny.Framework.Data.Configuration;
using Tiny.Framework.Utility;

namespace Document.API.Configuration
{
    /// <summary>
    /// posted article access scope configuration.
    /// </summary>
    internal sealed class PostedArticleAccessScopeConfiguration :
        ContextScopeConfiguration<PostedArticleAccessScope>,
        IConfigurePostedArticleAccessScope
    {
        /// <summary>
        /// gets or sets the host.
        /// </summary>
        internal IHostConfiguration Host { get; set; }

        /// <summary>
        /// set the host configuration.
        /// </summary>
        /// <param name="host">the host.</param>
        public void SetHostConfiguration(IHostConfiguration host)
        {
            It.IsNull(host)
                .AsGuard<ArgumentNullException>(nameof(host));

            Host = host;
        }

        /// <inheritdoc/>
        public override void LoadProvider(DbContextOptionsBuilder<PostedArticleAccessScope> builder)
        {
            It.IsNull(builder)
                .AsGuard<ArgumentNullException>(nameof(builder));
            It.IsNull(Host)
                .AsGuard<ArgumentNullException>("Host hasn't been setup in the configuration");

            var candidate = Path.Combine(Host.ContentRootPath, ConnectionDetails);

            ColorConsole.Write(ConsoleColor.Green, "attaching to:");
            ColorConsole.WriteLine(ConsoleColor.Yellow, candidate);

            builder.UseSqlite($"data source='{candidate}'");
        }
    }
}
