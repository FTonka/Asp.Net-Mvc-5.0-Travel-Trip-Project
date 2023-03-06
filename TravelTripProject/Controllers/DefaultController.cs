using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Blogs.ToList();
            return View(values);
        }
        public ActionResult About()
        {
            return View();
        }
        public PartialViewResult Partial1()
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial2()
        {
            var deger = c.Blogs.Where(x => x.ID == 1).ToList();
            return PartialView(deger);
        
       }
        public PartialViewResult Partial3()
        {
            var values = c.Blogs.ToList();
            return PartialView(values);

        }

        public PartialViewResult Partial4()
        {
            var values = c.Blogs.Take(3).ToList();
            return PartialView(values);

        }
        public PartialViewResult Partial5()
        {
            var values = c.Blogs.Take(3).OrderByDescending(x => x.ID).ToList();
            return PartialView(values);

        }
    }
}