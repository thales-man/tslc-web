// -----------------------------------------------------------------------------
// copyright (c) 2020, the striped lawn company limited. all rights reserved.
// the striped lawn company licenses this file to you under the GPLv3 license.
// see the LICENSE file in the project root for more information.
// -----------------------------------------------------------------------------
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Document.API.Adapters
{
    /// <summary>
    /// i adapt catalogue retrieval.
    /// </summary>
    public interface IAdaptCatalogueRetrieval
    {
        /// <summary>
        /// get the article catalogue...
        /// </summary>
        /// <returns>the result of the action.</returns>
        Task<IActionResult> GetCatalogue();
    }
}
