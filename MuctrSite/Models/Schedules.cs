using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MuctrSite.Models
{
    public class Schedules
    {
        [Key]
        public Guid id { get; set; }
        public string? name { get; set; }
        public string? url { get; set; }
        public Guid educationTypeId { get; set; }
        public DateTime publicationDate { get; set; }
    }
    public class SchedulesList
    {
        public IList<Schedules>? Schedules { get; set; }
    }
}
