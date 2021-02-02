// -----------------------------------------------------------------------------
// copyright (c) 2020, the striped lawn company limited. all rights reserved.
// the striped lawn company licenses this file to you under the GPLv3 license.
// see the LICENSE file in the project root for more information.
// -----------------------------------------------------------------------------
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Document.API.Coordinators;
using Microsoft.AspNetCore.Mvc;
using Tiny.Framework.Registration;
using Tiny.Framework.Utility;
using Tiny.Framework.Web.Adapters;

namespace Document.API.Adapters
{
    /// <summary>
    /// the file retrieval adapter.
    /// </summary>
    internal sealed class CatalogueRetrievalAdapter :
        IAdaptCatalogueRetrieval,
        ISupportServiceRegistration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogueRetrievalAdapter"/> class.
        /// </summary>
        /// <param name="coordinator">the file retrieval coordinator.</param>
        /// <param name="adapter">the action result operations adapter.</param>
        public CatalogueRetrievalAdapter(
            ICoordinateCatalogueRetrieval coordinator,
            IAdaptActionResultOperations adapter)
        {
            It.IsNull(coordinator)
                .AsGuard<ArgumentNullException>(nameof(coordinator));
            It.IsNull(adapter)
                .AsGuard<ArgumentNullException>(nameof(adapter));

            Coordinater = coordinator;
            Adapter = adapter;
        }

        /// <summary>
        /// gets the coordinator.
        /// </summary>
        internal ICoordinateCatalogueRetrieval Coordinater { get; }

        /// <summary>
        /// gets the adapter.
        /// </summary>
        internal IAdaptActionResultOperations Adapter { get; }

        /// <inheritdoc/>
        public async Task<IActionResult> GetCatalogue() =>
            await Adapter.Run(() => ProcessGetCatalogue(), "catalogue retrieval");

        /// <summary>
        /// process get catalogue...
        /// </summary>
        /// <returns>the result of the action.</returns>
        internal async Task<HttpResponseMessage> ProcessGetCatalogue() =>
            await Coordinater.GetCatalogue();
    }
}
