using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MuctrSite.Models
{
    public class Departments
    {
        [Key]
        public Guid id { get; set; }
        public string? name { get; set; }
    }
    public class DepList
    {
        public IList<Departments>? Departments { get; set; }
    }
}
