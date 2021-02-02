using Newtonsoft.Json;

namespace Document.API.Models
{
    /// <summary>
    /// the catalogue.
    /// </summary>
    public class Catalogue :
        ICatalogue
    {
        /// <summary>
        /// gets or sets the articles.
        /// </summary>
        [JsonProperty("articles")]
        public PostedArticle[] Articles { get; set; }
    }
}
