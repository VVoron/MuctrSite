using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MuctrSite.Models
{
    public class EducationType
    {
        [Key]
        public Guid id { get; set; }
        public string ?name { get; set; }
    }
    public class EducationList
    {
        public IList<EducationType>? EducationTypes { get; set; }
    }
}
