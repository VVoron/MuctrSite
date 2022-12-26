using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuctrSite.Models;

namespace MuctrSite.Controllers
{
    public class StudentsInfoController : Controller
    {
        HttpClient httpClient = new HttpClient();
        public async Task<IActionResult> Index()
        {
            ShadAndEdu _db = new ShadAndEdu();
            _db.StudentsInfo = await httpClient.GetFromJsonAsync<StudentList>("https://muctr-service-production.up.railway.app/api/studentsinfo");


            _db.EducationTypes = await httpClient.GetFromJsonAsync<EducationList>("https://muctr-service-production.up.railway.app/api/educationtype");
            IList<EducationType> educationList = new List<EducationType>();
            foreach (EducationType type in _db.EducationTypes.EducationTypes)
                if (type.name == "Бакалавриат/специалитет") { 
                    educationList.Add(type);
                    break;
                }
            foreach (EducationType type in _db.EducationTypes.EducationTypes)
                if (type.name == "Магистратура")
                {
                    educationList.Add(type);
                    break;
                }
            foreach (EducationType type in _db.EducationTypes.EducationTypes)
                if (type.name == "Аспирантура")
                {
                    educationList.Add(type);
                    break;
                }
            foreach (EducationType type in _db.EducationTypes.EducationTypes)
                if (type.name == "Отделение очно-заочного и заочного обучения")
                {
                    educationList.Add(type);
                    break;
                }
            foreach (EducationType type in _db.EducationTypes.EducationTypes)
                if (type.name == "Среднее профессиональное образование")
                {
                    educationList.Add(type);
                    break;
                }
            EducationList educList = new EducationList();
            educList.EducationTypes = educationList;
            _db.EducationTypes = educList;




            _db.Schedules = await httpClient.GetFromJsonAsync<SchedulesList>("https://muctr-service-production.up.railway.app/api/schedule");
            IList<Schedules> SchedulesList = new List<Schedules>();
            foreach (Schedules item in _db.Schedules.Schedules)
                if (item.name == "I курс")
                    SchedulesList.Add(item);
            foreach (Schedules item in _db.Schedules.Schedules)
                if (item.name == "II курс")
                    SchedulesList.Add(item);
            foreach (Schedules item in _db.Schedules.Schedules)
                if (item.name == "III курс")
                    SchedulesList.Add(item);
            foreach (Schedules item in _db.Schedules.Schedules)
                if (item.name == "IV курс")
                    SchedulesList.Add(item);
            foreach (Schedules item in _db.Schedules.Schedules)
                if (item.name == "V курс")
                    SchedulesList.Add(item);
            foreach (Schedules item in _db.Schedules.Schedules)
                if (item.name != "I курс" && item.name != "II курс" && item.name != "III курс" && item.name != "IV курс" && item.name != "V курс")
                    SchedulesList.Add(item);
            SchedulesList schList = new SchedulesList();
            schList.Schedules = SchedulesList;
            _db.Schedules = schList;
            return View(_db);
        }
    }
}
