using System;
using Newtonsoft.Json;

namespace Front.Services.Models
{
    internal sealed class PostedArticle :
        IPostedArticle
    {
        [JsonProperty("article")]
        public string Article { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("topic")]
        public string Topic { get; set; }

        [JsonProperty("year")]
        public string Year { get; set; }

        [JsonProperty("month")]
        public string Month { get; set; }

        [JsonProperty("publicationDate")]
        public DateTime PublicationDate { get; set; }

        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }
    }
}