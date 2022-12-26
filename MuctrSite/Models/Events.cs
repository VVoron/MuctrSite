using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MuctrSite.Models
{
    public class Events
    {
        [Key]
        public Guid id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public DateTime publicationDate { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string? mediaUrl { get; set; }
    }
    public class EventsList
    {
        public IList<Events>? Events { get; set; }
    }
}
