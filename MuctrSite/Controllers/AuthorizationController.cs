using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuctrSite.Models;
using System.Security.Claims;

namespace MuctrSite.Controllers
{
    public class AuthorizationController : Controller
    {
        List<User> peoples = new List<User>
        {
            new User {Name = "admin", Password = "admin", Role = MuctrSite.Enums.Role.Admin},
            new User {Name = "employer", Password = "123123", Role = MuctrSite.Enums.Role.Normal}
        };

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var response = Login(user);
                if (response != null)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(response));
                    TempData["warning"] = "Добро пошаловать, " + user.Name;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        private ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim> {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            return new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }

        public ClaimsIdentity? Login(LoginViewModel model)
        {
            try
            {
                var user = peoples.FirstOrDefault(x => x.Name == model.Name);
                if (user == null)
                {
                    return null;
                }
                if (user.Password != model.Password)
                    return null;
                var result = Authenticate(user);
                return result;
            }
            catch
            { 
                return null;
            }
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["warning"] = "Вы вышли из аккаунта";
            return RedirectToAction("Index", "Home");
        }
    }
}
