using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Blogs.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult DeleteBlog(int id)
        {
            var b=c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult FetchBlog(int id)
        {
            var fb = c.Blogs.Find(id);
            return View("FetchBlog", fb);

        }
        public ActionResult UpdateBlog(Blog b)
        {
            var ub = c.Blogs.Find(b.ID);
            ub.Baslik = b.Baslik;
            ub.Aciklama = b.Aciklama;
            ub.BlogImg = b.BlogImg;
            ub.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Comments()
        {
            var comments = c.Comments.ToList();
            return View(comments);
        }
        public ActionResult DeleteComment(int id)
        {
            var b = c.Comments.Find(id);
            c.Comments.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult FetchComment(int id)
        {
            var fc = c.Comments.Find(id);
            return View("FetchComment", fc);

        }
        public ActionResult UpdateComment(Comment com)
        {
            var uc = c.Comments.Find(com.ID);
            uc.KullaniciAdi =com.KullaniciAdi;
            uc.Mail = com.Mail;
            uc.yorum =com.yorum;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}