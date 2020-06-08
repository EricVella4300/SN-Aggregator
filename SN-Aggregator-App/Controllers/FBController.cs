using SN_Aggregator_App.Facebook.Controller;
using SN_Aggregator_App.Facebook.POCO;
using SN_Aggregator_App.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SN_Aggregator_App.Controllers
{
    public class FBController : System.Web.Mvc.Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult PageFeed ()
        {
            Settings set = db.settings.Find(User.Identity.Name);
            List<PageFeedModel> feed = new List<PageFeedModel>(); 
            FacebookController fbcontroller = new FacebookController();
            List<FeedPost> posts = fbcontroller.GetPageFeed(set.FBidentification);
            foreach(FeedPost post in posts)
            {
                PageFeedModel pfm = new PageFeedModel();
                pfm.id = post.getId();
                pfm.datecreated = post.getDateTime();
                pfm.message = post.getMessage();
                feed.Add(pfm);
            }
            return View(feed);
        }

        [HttpPost]
        public ActionResult PageFeed(string txtMsg)
        {
            FacebookController fbcontroller = new FacebookController();
            fbcontroller.SetPageFeed(txtMsg);
            return RedirectToAction("PageFeed");
        }

        
        public ActionResult PageFeedLikes()
        {
            Settings set = db.settings.Find(User.Identity.Name);
            List<PageFeedModel> feed = new List<PageFeedModel>();
            FacebookController fbcontroller = new FacebookController();
            List<FeedPost> posts = fbcontroller.GetPageFeed(set.FBidentification);
            foreach (FeedPost post in posts)
            {
                PageFeedModel pfm = new PageFeedModel();
                pfm.id = post.getId();
                pfm.datecreated = post.getDateTime();
                pfm.message = post.getMessage();
                feed.Add(pfm);
            }
            return View(feed);
        }

        
        public ActionResult ViewLikes(string Object_id)
        {
            List<FeedLikesModel> likes = new List<FeedLikesModel>();
            FacebookController fbcontroller = new FacebookController();
            List<PostLikes> posts = fbcontroller.GetObjectsLikes(Object_id);
            foreach (PostLikes post in posts)
            {
                FeedLikesModel flm = new FeedLikesModel();
                flm.id = post.getId();
                flm.name = post.getName();
                likes.Add(flm);
            }
            return View(likes);
        }
    }
}