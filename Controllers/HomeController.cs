using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteUploadAnh.Models;

namespace WebsiteUploadAnh.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext db = new MyDbContext();
        
        public ActionResult Index()
        {
            var user = (USER) Session["User"];
            if (user == null) return RedirectToAction("Login");
            var model = db.IMAGES.Where(x => x.UserID == user.UserID).OrderByDescending(x=> x.Imagedate).ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Album()
        {
            var user = (USER)Session["User"];
             if (user == null) return RedirectToAction("Login");
            var model = db.ALBUMS.Where(x => x.UserID == user.UserID).ToList();
            string [] path = new string[1000];
            int i = 0;
            foreach (var it in model)
            {
                var x = db.IMAGES.First(t =>t.AlbumID == it.AlbumID);
                path[i] = x.ImageUrl;
                i++;
            }
            ViewBag.path = path;
            return View(model);
        }
        public ActionResult DetailAlbum(int id)
        {
            var model = db.IMAGES.Where(t => t.AlbumID ==  id).ToList();
            ViewBag.album = db.ALBUMS.First(x => x.AlbumID == id);
            return View(model);
        }
        public ActionResult Share()
        {
            var user = (USER)Session["User"];
            if (user == null) return RedirectToAction("Login");
            var model = db.SHAREDs.Where(x => x.UserID == user.UserID).ToList();
           
            List<ALBUM> album = new List<ALBUM>();
            List<IMAGE> image = new List<IMAGE>();
            foreach (var it in model)
            {
                if (it.ImageID != null) {
                    var d = db.IMAGES.First(t => t.ImageID == it.ImageID);
                    image.Add(d);
                } 
                else
                {
                    if (it.AlbumID != null)
                    {
                        var d = db.ALBUMS.First(t => t.AlbumID == it.AlbumID);
                        album.Add(d);
                    }
                }
            }
            string[] path = new string[1000];
            int i = 0;
            foreach (var it in album)
            {
                var x = db.IMAGES.First(t => t.AlbumID == it.AlbumID);
                path[i] = x.ImageUrl;
                i++;
            }
            ViewBag.path = path;
            ViewBag.album = album;
            ViewBag.image = image;
            return View(model);
        }
        public ActionResult Login(string FailureMessage)
        {
            ViewData["FailureMessage"] = FailureMessage;
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}