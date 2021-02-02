using System;

namespace Front.Services.Models
{
    public interface IPostedArticle
    {
        string Article { get; }
        string Title { get; }
        string Topic { get; }
        string Year { get; }
        string Month { get; }
        DateTime PublicationDate { get; }
        string Alias { get; }
        string Path { get; }
    }
}