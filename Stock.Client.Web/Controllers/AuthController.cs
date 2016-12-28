using System;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Stock.Client.Web.Tools;
using Stock.Client.Web.ViewModels;
using Stock.Core.Dto;
using Stock.Core.Services;

namespace Stock.Client.Web.Controllers
{
    public class AuthController : Controller
    {
        [Inject]
        public IUserService UserService { get; set; }

        public ActionResult Logon(LogonViewModel model)
        {
            return View(model);
        }

        public ActionResult Login(LogonViewModel model)
        {
            var result = UserService.Login(model.Email, model.Password);

            if (result.IsAuthenticated)
            {
                Response.SetAuth(result.User.Email);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Logon", new LogonViewModel { Email = model.Email, Message = result.Message });
            }
        }

        public ActionResult Logout()
        {
            HttpCookie aCookie;
            string cookieName;
            int limit = Request.Cookies.Count;

            for (int i = 0; i < limit; i++)
            {
                cookieName = Request.Cookies[i].Name;
                aCookie = new HttpCookie(cookieName);
                aCookie.Value = "";
                Response.Cookies.Set(aCookie);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Register(UserDto dto)
        {
            var result = UserService.Register(dto.Name, dto.Email, dto.Password);
            
            return RedirectToAction("Index", "Home");
        }
    }
}