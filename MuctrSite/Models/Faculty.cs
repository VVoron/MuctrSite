using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MuctrSite.Models
{
    public class Faculty
    {
        [Key]
        public Guid id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
    }

    public class FacultyList
    {
        public IList<Faculty>? Faculties { get; set; }
    }
}
