using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MuctrSite.Models
{
    public class StudentsInfo
    {
        public Guid id { get; set; }
        public string ?name { get; set; }
        public string ?description { get; set; }
    }
    public class StudentList
    {
        public IList<StudentsInfo>? StudentsInfo { get; set; }
    }
}
