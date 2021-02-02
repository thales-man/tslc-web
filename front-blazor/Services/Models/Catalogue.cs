// -----------------------------------------------------------------------------
// copyright (c) 2020, the striped lawn company limited. all rights reserved.
// the striped lawn company licenses this file to you under the GPLv3 license.
// see the LICENSE file in the project root for more information.
// -----------------------------------------------------------------------------
using Newtonsoft.Json;

namespace Front.Services.Models
{
    internal sealed class Catalogue :
        ICatalogue
    {
        [JsonProperty("articles")]
        PostedArticle[] Articles { get; set; }

        IPostedArticle[] ICatalogue.Articles => Articles;
    }
}