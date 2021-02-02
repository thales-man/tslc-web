// -----------------------------------------------------------------------------
// copyright (c) 2020, the striped lawn company limited. all rights reserved.
// the striped lawn company licenses this file to you under the GPLv3 license.
// see the LICENSE file in the project root for more information.
// -----------------------------------------------------------------------------
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Document.API.Factories;
using Document.API.Models;
using Tiny.Framework.IO;
using Tiny.Framework.Registration;
using Tiny.Framework.Utility;
using Tiny.Framework.Web.Factories;

namespace Document.API.Coordinators
{
    /// <summary>
    /// the catalogue retrieval coordinator.
    /// </summary>
    public sealed class CatalogueRetrievalCoordinator :
        ICoordinateCatalogueRetrieval,
        ISupportServiceRegistration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogueRetrievalCoordinator"/> class.
        /// </summary>
        /// <param name="access">the data access factory.</param>
        /// <param name="factory">the response factory.</param>
        /// <param name="converter">the json converter.</param>
        public CatalogueRetrievalCoordinator(
            ICreatePostedArticleAccessScopes access,
            ICreateHttpResponseMessages factory,
            ISerializeJsonTypes converter)
        {
            It.IsNull(access)
                .AsGuard<ArgumentNullException>(nameof(access));
            It.IsNull(factory)
                .AsGuard<ArgumentNullException>(nameof(factory));
            It.IsNull(converter)
                .AsGuard<ArgumentNullException>(nameof(converter));

            DataAccess = access;
            Response = factory;
            Converter = converter;
        }

        /// <summary>
        /// gets data access.
        /// </summary>
        public ICreatePostedArticleAccessScopes DataAccess { get; }

        /// <summary>
        /// gets the http response message factory.
        /// </summary>
        internal ICreateHttpResponseMessages Response { get; }

        /// <summary>
        /// gets the configuration details.
        /// </summary>
        internal ISerializeJsonTypes Converter { get; }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> GetCatalogue()
        {
            using (var scope = DataAccess.BeginScope())
            {
                var catalogue = await scope.GetDocumentCatalogue();
                var payload = await GetContentPayloadFor(catalogue);
                return Response.Create(HttpStatusCode.OK, payload);
            }
        }

        /// <summary>
        /// get content payload for...
        /// </summary>
        /// <param name="theCatalogue">the catalogue.</param>
        /// <returns>the catalogue string.</returns>
        internal async Task<string> GetContentPayloadFor(ICatalogue theCatalogue) =>
            await Task.FromResult(Converter.ToString(theCatalogue));
    }
}
