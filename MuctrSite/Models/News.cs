using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MuctrSite.Models
{
    public class News
    {
        [Key]
        public Guid id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public DateTime publicationDate { get; set; }
        public string? mediaUrl { get; set; }
    }

    public class NewsList
    {
        public IList<News>? News { get; set; }
    }
}
