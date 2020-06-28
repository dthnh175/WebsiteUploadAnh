using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteUploadAnh.Models;

namespace WebsiteUploadAnh.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(USER user_auth_info)
        {
            MyDbContext db = new MyDbContext();
            USER user = db.USERS.SingleOrDefault(x => x.UserName == user_auth_info.UserName && x.Passwords == user_auth_info.Passwords);
            
            // Đăng nhập thành công
            if (user != null)
            {
                Session["User"] = user;
                return RedirectToAction("Index", "Home");
            }
            
            // Đăng nhập không thành công
            return RedirectToAction("Login", "Home", new { FailureMessage = "Đăng nhập không thành công" });
        }

        [HttpPost]
        public ActionResult Register(USER new_user_info)
        {
            MyDbContext db = new MyDbContext();

            // check if email existed
            var user = db.USERS.SingleOrDefault(x => x.UserEmail == new_user_info.UserEmail);
            if (user != null)
            {
                return RedirectToAction("Register", "Home");
            }

            // check if username existed
            user = db.USERS.SingleOrDefault(x => x.UserName == new_user_info.UserName);
            if (user != null)
            {
                return RedirectToAction("Register", "Home");
            }

            user = db.USERS.Add(new_user_info);
            db.SaveChanges();
            Session["User"] = user;
            return RedirectToAction("Index", "Home");
        }
    }
}