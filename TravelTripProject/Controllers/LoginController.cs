using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin p)
        {
            var user = c.Admins.FirstOrDefault(x => x.Kullanici == p.Kullanici && x.Sifre == p.Sifre);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Kullanici, false);
                Session["Kullanici"] = user.Kullanici.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }

    }
}