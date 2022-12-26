using Microsoft.AspNetCore.Mvc;
using MuctrSite.Models;

namespace MuctrSite.Controllers
{
    public class DepartmentsController : Controller
    {
        static HttpClient httpClient = new HttpClient();
        public async Task<IActionResult> Index()
        {
            FacultyList _db = await httpClient.GetFromJsonAsync<FacultyList>("https://muctr-service-production.up.railway.app/api/faculty");
            return View(_db);
        }

        public async Task<IActionResult> GetDepartment(Guid? id)
        {
            DepAndEmpl _db = new DepAndEmpl();

            _db.Dean = await httpClient.GetFromJsonAsync<Dean>($"https://muctr-service-production.up.railway.app/api/dean/{id}");

            FacultyList _faculty = await httpClient.GetFromJsonAsync<FacultyList>("https://muctr-service-production.up.railway.app/api/faculty");
            foreach (Faculty fac in _faculty.Faculties)
                if (fac.id == id)
                {
                    _db.FacultyName = fac.name;
                    break;
                }
            _db.Departments = await httpClient.GetFromJsonAsync<DepList>($"https://muctr-service-production.up.railway.app/api/department?facultyId={id}");
            _db.Professors = await httpClient.GetFromJsonAsync<EmployersList>($"https://muctr-service-production.up.railway.app/api/professor?facultyId={id}");


            EmployersList emplList = new EmployersList();
            foreach (Employers empl in _db.Professors.Professors)
                if (empl.position == "Заведующий кафедрой")
                    emplList.Professors.Add(empl);
            foreach (Employers empl in _db.Professors.Professors)
                if (empl.position == "Профессор")
                    emplList.Professors.Add(empl);
            foreach (Employers empl in _db.Professors.Professors)
                if (empl.position != "Профессор" && empl.position != "Заведующий кафедрой")
                    emplList.Professors.Add(empl);


            _db.Professors = emplList;
            return View(_db);
        }
    }
}
