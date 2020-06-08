using SN_Aggregator_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SN_Aggregator_App.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Settings()
        {
            return View();
        }

        public void AddFBToken(string token)
        {
            Settings Set = db.settings.Find(User.Identity.Name);
            if (Set != null)
            {
                Set.FBidentification = token;
            }
            else
            {
                Set = new Settings();
                Set.user_email = User.Identity.Name;
                Set.FBidentification = token;
                db.settings.Add(Set);
            }
            db.SaveChanges();
            ViewData["FBAccessToken"] = token;
        }

        public void AddTWToken(string token)
        {
            Settings Set = db.settings.Find(User.Identity.Name);
            if (Set != null)
            {
                Set.TwitterIdentification = token;
            }
            else
            {
                Set = new Settings();
                Set.user_email = User.Identity.Name;
                Set.TwitterIdentification = token;
                db.settings.Add(Set);
            }
            db.SaveChanges();
        }
    }
}