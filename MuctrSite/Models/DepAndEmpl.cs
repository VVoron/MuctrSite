using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MuctrSite.Models
{
    public class DepAndEmpl
    {
        public string? FacultyName { get; set; }
        public EmployersList? Professors { get; set; }
        public DepList? Departments { get; set; }
        public Dean Dean { get; set; }
    }
}
