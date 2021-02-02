using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Document.API.Models
{
    /// <summary>
    /// i document detail.
    /// </summary>
    [Serializable]
    [Table("PostedArticle")]
    public class PostedArticle :
        IPostedArticle
    {
        /// <inheritdoc/>
        [Key]
        [Required]
        [Column("Article")]
        public string Article { get; set; }

        /// <inheritdoc/>
        [Required]
        [Column("Title")]
        [StringLength(250)]
        public string Title { get; set; }

        /// <inheritdoc/>
        [Required]
        [Column("Topic")]
        public string Topic { get; set; }

        /// <inheritdoc/>
        [Column("Year")]
        public string Year { get; set; }

        /// <inheritdoc/>
        [Column("Month")]
        public string Month { get; set; }

        /// <inheritdoc/>
        [Required]
        [Column("PublicationDate")]
        public DateTime PublicationDate { get; set; }

        /// <inheritdoc/>
        [Column("Alias")]
        public string Alias { get; set; }

        /// <inheritdoc/>
        [Column("Path")]
        [StringLength(250)]
        public string Path { get; set; }
    }
}
