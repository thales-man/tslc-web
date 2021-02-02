using System;
using Newtonsoft.Json;

namespace Document.API.Models
{
    /// <summary>
    /// i posted article.
    /// </summary>
    public interface IPostedArticle
    {
        /// <summary>
        /// gets the article.
        /// </summary>
        [JsonProperty("article")]
        string Article { get; }

        /// <summary>
        /// gets the title.
        /// </summary>
        [JsonProperty("title")]
        string Title { get; }

        /// <summary>
        /// gets the publication date.
        /// </summary>
        [JsonProperty("topic")]
        string Topic { get; }

        /// <summary>
        /// gets the publication date.
        /// </summary>
        [JsonProperty("year")]
        string Year { get; }

        /// <summary>
        /// gets the month.
        /// </summary>
        [JsonProperty("month")]
        string Month { get; }

        /// <summary>
        /// gets the publication date.
        /// </summary>
        [JsonProperty("publicationDate")]
        DateTime PublicationDate { get; }

        /// <summary>
        /// gets the alias.
        /// </summary>
        [JsonProperty("alias")]
        string Alias { get; }

        /// <summary>
        /// gets the content.
        /// </summary>
        [JsonProperty("path")]
        string Path { get; }
    }
}
