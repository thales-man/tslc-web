namespace Document.API.Models
{
    /// <summary>
    /// i catalogue.
    /// </summary>
    public interface ICatalogue
    {
        /// <summary>
        /// gets the articles.
        /// </summary>
        PostedArticle[] Articles { get; }
    }
}
