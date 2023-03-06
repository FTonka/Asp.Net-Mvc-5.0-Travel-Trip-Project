using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;
namespace TravelTripProject.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogYorum by = new BlogYorum();

        public ActionResult Index()
        {
            by.Deger1 = c.Blogs.ToList();
            by.Deger3 = c.Blogs.Take(3).ToList();
            return View(by);
        }
        public ActionResult BlogDetails(int id) {
            by.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = c.Comments.Where(x => x.BlogID == id).ToList();
            return View(by);
        
            
        }
        [HttpGet]
        public PartialViewResult AddCommentToBlog(int id)
        {
            ViewBag.i = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult AddCommentToBlog(Comment com)
        {
            c.Comments.Add(com);
            c.SaveChanges();

            return PartialView();
        }
    }
}