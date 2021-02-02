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
    /// i adapt file retrieval.
    /// </summary>
    public interface IAdaptFileRetrieval
    {
        /// <summary>
        /// get the article for...
        /// </summary>
        /// <param name="theTopic">the topic.</param>
        /// <param name="andSubject">and subject.</param>
        /// <returns>the result of the action.</returns>
        Task<IActionResult> GetArticleFor(string theTopic, string andSubject);

        /// <summary>
        /// get the article item for...
        /// </summary>
        /// <param name="theTopic">the topic.</param>
        /// <param name="theSubject">the subject.</param>
        /// <param name="andFormat">and format.</param>
        /// <returns>the result of the action.</returns>
        Task<IActionResult> GetArticleItemFor(string theTopic, string theSubject, string andFormat);
    }
}
