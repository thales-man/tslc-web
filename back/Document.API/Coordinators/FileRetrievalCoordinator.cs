// -----------------------------------------------------------------------------
// copyright (c) 2020, the striped lawn company limited. all rights reserved.
// the striped lawn company licenses this file to you under the GPLv3 license.
// see the LICENSE file in the project root for more information.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tiny.Framework.Container;
using Tiny.Framework.Registration;
using Tiny.Framework.Utility;
using Tiny.Framework.Web.Factories;

namespace Document.API.Coordinators
{
    /// <summary>
    /// the file retrieval coordinator.
    /// </summary>
    public sealed class FileRetrievalCoordinator :
        ICoordinateFileRetrieval,
        ISupportServiceRegistration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileRetrievalCoordinator"/> class.
        /// </summary>
        /// <param name="factory">the response factory.</param>
        /// <param name="configuration">the configuration details.</param>
        public FileRetrievalCoordinator(
            ICreateHttpResponseMessages factory,
            IHostConfiguration configuration)
        {
            It.IsNull(factory)
                .AsGuard<ArgumentNullException>(nameof(factory));
            It.IsNull(configuration)
                .AsGuard<ArgumentNullException>(nameof(configuration));

            Response = factory;
            Configuration = configuration;
        }

        /// <summary>
        /// gets the http response message factory.
        /// </summary>
        internal ICreateHttpResponseMessages Response { get; }

        /// <summary>
        /// gets the configuration details.
        /// </summary>
        internal IHostConfiguration Configuration { get; }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> GetArticleFor(string theTopic, string andSubject)
        {
            var result = await GetArticleItemBytesFor(theTopic, andSubject, "md");

            return Response.Create(HttpStatusCode.OK, Encoding.UTF8.GetString(result), "text/plain");
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> GetArticleItemFor(string theTopic, string theSubject, string andFormat)
        {
            var result = await GetArticleItemBytesFor(theTopic, theSubject, andFormat);

            return Response.Create(HttpStatusCode.OK, result, $"image/{andFormat}");
        }

        /// <summary>
        /// get article item bytes for...
        /// </summary>
        /// <param name="theTopic">the topic.</param>
        /// <param name="theSubject">the subject.</param>
        /// <param name="andFormat">and format.</param>
        /// <returns>a viable path (or throws).</returns>
        internal async Task<byte[]> GetArticleItemBytesFor(string theTopic, string theSubject, string andFormat)
        {
            var candidate = await GetArticleItemPathFor(theTopic, theSubject, andFormat);
            return File.ReadAllBytes(candidate);
        }

        /// <summary>
        /// get the article item path for...
        /// </summary>
        /// <param name="theTopic">the topic.</param>
        /// <param name="theSubject">the subject.</param>
        /// <param name="andFormat">and format.</param>
        /// <returns>a viable path (or throws).</returns>
        internal async Task<string> GetArticleItemPathFor(string theTopic, string theSubject, string andFormat) =>
            await Task.Run(() =>
            {
                var candidate = Path.Combine(Configuration.StaticFilePath, "articles", theTopic, $"{theSubject}.{andFormat}");

                (!File.Exists(candidate))
                     .AsGuard<FileNotFoundException>();

                return candidate;
            });
    }
}
