using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MuctrSite.Controllers
{
    public class UniversityMapController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
