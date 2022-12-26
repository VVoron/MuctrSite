using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MuctrSite.Models
{
    public class ShadAndEdu
    {
        public StudentList? StudentsInfo { get; set; }
        public SchedulesList? Schedules { get; set; }
        public EducationList? EducationTypes { get; set; }
    }
}
