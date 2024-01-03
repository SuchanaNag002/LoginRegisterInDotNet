using LoginRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginRegister.Controllers
{
    public class HomeController : Controller
    {
        LoginExampleEntities db = new LoginExampleEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Signup()
        {
            ViewBag.Message = "Your signup page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your login page.";

            return View();
        }

        [HttpPost]
        public ActionResult Signup(User user)
        {
            if(db.Users.Any(x => x.email == user.email))
            {
                ViewBag.Notification = "This account already exists";
            }
            else
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var checkLogin = db.Users.Where(x => x.email.Equals(user.email) && x.password.Equals(user.password)).FirstOrDefault();
            if (checkLogin != null)
            {
                Session["email"] = user.email.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Wrong username or wrong password";
            }
            return View();
        }
    }
}