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
    internal sealed class FileRetrievalAdapter :
        IAdaptFileRetrieval,
        ISupportServiceRegistration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileRetrievalAdapter"/> class.
        /// </summary>
        /// <param name="coordinator">the file retrieval coordinator.</param>
        /// <param name="adapter">the action result operations adapter.</param>
        public FileRetrievalAdapter(
            ICoordinateFileRetrieval coordinator,
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
        internal ICoordinateFileRetrieval Coordinater { get; }

        /// <summary>
        /// gets the adapter.
        /// </summary>
        internal IAdaptActionResultOperations Adapter { get; }

        /// <inheritdoc/>
        public async Task<IActionResult> GetArticleFor(string theTopic, string andSubject) =>
            await Adapter.Run(() => ProcessGetArticleFor(theTopic, andSubject), "article retrieval");

        /// <inheritdoc/>
        public async Task<IActionResult> GetArticleItemFor(string theTopic, string theSubject, string andFormat) =>
            await Adapter.Run(() => ProcessGetArticleItemFor(theTopic, theSubject, andFormat), "article image retrieval");

        /// <summary>
        /// process get the article for...
        /// </summary>
        /// <param name="theTopic">the topic.</param>
        /// <param name="andSubject">and subject.</param>
        /// <returns>the result of the action.</returns>
        internal async Task<HttpResponseMessage> ProcessGetArticleFor(string theTopic, string andSubject) =>
            await Coordinater.GetArticleFor(theTopic, andSubject);

        /// <summary>
        /// process get the article item for...
        /// </summary>
        /// <param name="theTopic">the topic.</param>
        /// <param name="theSubject">the subject.</param>
        /// <param name="andFormat">and format.</param>
        /// <returns>the result of the action.</returns>
        internal async Task<HttpResponseMessage> ProcessGetArticleItemFor(string theTopic, string theSubject, string andFormat) =>
            await Coordinater.GetArticleItemFor(theTopic, theSubject, andFormat);
    }
}
