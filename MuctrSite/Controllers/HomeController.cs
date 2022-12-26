using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuctrSite.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace MuctrSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        static HttpClient httpClient = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            NewsAndEvents _db = new NewsAndEvents();
            _db.Events = await httpClient.GetFromJsonAsync<EventsList>("https://muctr-service-production.up.railway.app/api/event?limit=3&unfinished=false");
            _db.News = await httpClient.GetFromJsonAsync<NewsList>("https://muctr-service-production.up.railway.app/api/news?limit=3");
            return View(_db);
        }

        public async Task<IActionResult> GetAllNews()
        {
            NewsList _db = await httpClient.GetFromJsonAsync<NewsList>("https://muctr-service-production.up.railway.app/api/news?limit=10");
            return View(_db);
        }
        public async Task<IActionResult> GetAllActions()
        {
            EventsList _db = await httpClient.GetFromJsonAsync<EventsList>("https://muctr-service-production.up.railway.app/api/event?limit=10&unfinished=false");
            return View(_db);
        }

        
        public async Task<IActionResult> GetNews(Guid? id)
        {
            News _db = await httpClient.GetFromJsonAsync<News>($"https://muctr-service-production.up.railway.app/api/news/{id}");
            return View(_db);
        }
        public async Task<IActionResult> GetActions(Guid? id)
        {
            Events _db = await httpClient.GetFromJsonAsync<Events>($"https://muctr-service-production.up.railway.app/api/event/{id}");
            return View(_db);
        }

        //Get
        public IActionResult CreateNews()
        {
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNews(News obj)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(obj.title);
                var content = new StringContent(JsonConvert.SerializeObject(new
                {
                    title = obj.title,
                    description = obj.description,
                    mediaUrl = obj.mediaUrl
                }), Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync("https://muctr-service-production.up.railway.app/api/news", content);
                TempData["success"] = "Новость успешно создана";
                return RedirectToAction("GetAllNews");
            }
            return View(obj);
        }
        //Get
        public async Task<IActionResult> EditNews(Guid? id)
        {
            News obj = await httpClient.GetFromJsonAsync<News>($"https://muctr-service-production.up.railway.app/api/news/{id}");
            return View(obj);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNews(News obj)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(new {
                    id = obj.id, 
                    title = obj.title, 
                    description = obj.description,
                    publicationDate = obj.publicationDate,
                    mediaUrl = obj.mediaUrl
                }), Encoding.UTF8, "application/json");
                await httpClient.PutAsync("https://muctr-service-production.up.railway.app/api/news", content);
                TempData["success"] = "Новость успешно отредактирована";
                return RedirectToAction("GetAllNews");
            }
            return View(obj);
        }
        public async Task<IActionResult> DeleteNews(Guid? id)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync(
               $"https://muctr-service-production.up.railway.app/api/news/{id}");
            TempData["success"] = "Запись была успешно удалена";
            return RedirectToAction("GetAllNews", "Home");
        }

        //Get
        public IActionResult CreateAction()
        {
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAction(Events obj)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(obj.title);
                var content = new StringContent(JsonConvert.SerializeObject(new
                {
                    title = obj.title,
                    description = obj.description,
                    startTime = obj.startTime,
                    endTime = obj.endTime,
                    mediaUrl = obj.mediaUrl
                }), Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync("https://muctr-service-production.up.railway.app/api/event", content);
                TempData["success"] = "Событие успешно удалено";
                return RedirectToAction("GetAllActions");
            }
            return View(obj);
        }

        //Get
        public async Task<IActionResult> EditAction(Guid? id)
        {
            Events obj = await httpClient.GetFromJsonAsync<Events>($"https://muctr-service-production.up.railway.app/api/event/{id}");
            return View(obj);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAction(Events obj)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(new
                {
                    id = obj.id,
                    title = obj.title,
                    description = obj.description,
                    startTime = obj.startTime,
                    endTime = obj.endTime,
                    mediaUrl = obj.mediaUrl
                }), Encoding.UTF8, "application/json");
                await httpClient.PutAsync("https://muctr-service-production.up.railway.app/api/event", content);
                TempData["success"] = "Событие успешно отредактировано";
                return RedirectToAction("GetAllActions");
            }
            return View(obj);
        }
        public async Task<IActionResult> DeleteAction(Guid? id)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync(
               $"https://muctr-service-production.up.railway.app/api/event/{id}");
            TempData["success"] = "Запись была успешно удалена";
            return RedirectToAction("GetAllActions", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}