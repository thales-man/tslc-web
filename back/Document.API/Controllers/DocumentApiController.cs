// -----------------------------------------------------------------------------
// copyright (c) 2020, the striped lawn company limited. all rights reserved.
// the striped lawn company licenses this file to you under the GPLv3 license.
// see the LICENSE file in the project root for more information.
// -----------------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using Document.API.Adapters;
using Microsoft.AspNetCore.Mvc;
using Tiny.Framework.Utility;

namespace WebAPI.Controllers
{
    /// <summary>
    /// web api controller.
    /// </summary>
    [ApiController]
    public sealed class DocumentApiController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentApiController"/> class.
        /// </summary>
        /// <param name="catalogueAdapter">the catalogue retrieval adapter.</param>
        /// <param name="fileAdapter">the file retrieval adapter.</param>
        public DocumentApiController(
            IAdaptCatalogueRetrieval catalogueAdapter,
            IAdaptFileRetrieval fileAdapter)
        {
            It.IsNull(catalogueAdapter)
                .AsGuard<ArgumentNullException>(nameof(catalogueAdapter));
            It.IsNull(fileAdapter)
                .AsGuard<ArgumentNullException>(nameof(fileAdapter));

            CatalogueAdapter = catalogueAdapter;
            FileAdapter = fileAdapter;
        }

        /// <summary>
        /// gets or sets the catalogue adapter.
        /// </summary>
        internal IAdaptCatalogueRetrieval CatalogueAdapter { get; set; }

        /// <summary>
        /// gets or sets the (message) mediator.
        /// </summary>
        /// <value>the mediator.</value>
        internal IAdaptFileRetrieval FileAdapter { get; set; }

        /// <summary>
        /// get the article catalogue.
        /// </summary>
        /// <returns>the result of the action.</returns>
        [HttpGet("/articles/catalogue")]
        public async Task<IActionResult> GetCatalogue() =>
            await CatalogueAdapter.GetCatalogue();
    }
}
