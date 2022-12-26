using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MuctrSite.Models
{
    public class Employers
    {
        [Key]
        public Guid id { get; set; }
        public string? surname { get; set; }
        public string? firstName { get; set; }
        public string? secondName { get; set; }
        public Guid departmentId { get; set; }
        public string? position { get; set; }
        public string? phoneNumber { get; set; }
        public string? email { get; set; }
        public string? mediaUrl { get; set; }
    }

    public class EmployersList
    {
        public IList<Employers>? Professors { get; set; }
        public EmployersList() => Professors = new List<Employers>();
    }
}
