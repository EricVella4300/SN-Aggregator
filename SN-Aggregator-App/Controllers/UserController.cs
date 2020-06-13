using SN_Aggregator_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TweetSharp;

namespace SN_Aggregator_App.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Settings()
        {
            Settings Set = db.settings.Find(User.Identity.Name);
            if (Set == null)
            {
                Set = new Settings();
                Set.user_email = User.Identity.Name;
                Set.birthdayperm = false;
                Set.fnameperm = false;
                Set.hometownperm = false;
                Set.likesperm = false;
                Set.lnameperm = false;
                Set.quotesperm = false;
                db.settings.Add(Set);
                db.SaveChanges();
            }
            return View(Set);
        }

        [HttpPost]
        public ActionResult Settings(Settings set)
        {
            Settings Setting = db.settings.Find(User.Identity.Name);
            Setting.hometownperm = set.hometownperm;
            Setting.likesperm = set.likesperm;
            Setting.birthdayperm = set.birthdayperm;
            Setting.fnameperm = set.fnameperm;
            Setting.lnameperm = set.lnameperm;
            Setting.quotesperm = set.quotesperm;
            db.SaveChanges();
            return RedirectToAction("Settings");
        }


        public void AddFBDetails(string token, string id)
        {
            Settings Set = db.settings.Find(User.Identity.Name);
            if (Set != null)
            {
                Set.FBidentification = token;
                Set.FBuserid = id;
            }
            else
            {
                Set = new Settings();
                Set.user_email = User.Identity.Name;
                Set.FBidentification = token;
                Set.FBuserid = id;
                db.settings.Add(Set);
            }
            db.SaveChanges();
            ViewData["FBAccessToken"] = token;
        }

        public void AddTWToken(string token, string id)
        {
            Settings Set = db.settings.Find(User.Identity.Name);
            if (Set != null)
            {
                Set.Twitteruserid = id;
                Set.TwitterIdentification = token;
            }
            else
            {
                Set = new Settings();
                Set.user_email = User.Identity.Name;
                Set.Twitteruserid = id;
                Set.TwitterIdentification = token;
                db.settings.Add(Set);
            }
            db.SaveChanges();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult logOff()
        {
            AccountController ac = new AccountController();
            ac.Logout();
            return RedirectToAction("Login");
        }
    }
}