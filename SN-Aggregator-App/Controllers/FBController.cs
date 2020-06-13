using SN_Aggregator_App.API.Controller;
using SN_Aggregator_App.API.POCO;
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
            Settings set = db.settings.Find(User.Identity.Name);
            FacebookController fbcontroller = new FacebookController();
            fbcontroller.SetPageFeed(txtMsg, set.FBuserid, set.FBidentification);
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
            Settings set = db.settings.Find(User.Identity.Name);
            List<FeedLikesModel> likes = new List<FeedLikesModel>();
            FacebookController fbcontroller = new FacebookController();
            List<PostLikes> posts = fbcontroller.GetObjectsLikes(Object_id, set.FBuserid, set.FBidentification);
            foreach (PostLikes post in posts)
            {
                FeedLikesModel flm = new FeedLikesModel();
                flm.id = post.getId();
                flm.name = post.getName();
                likes.Add(flm);
            }
            return View(likes);
        }

        public ActionResult ViewImages()
        {
            Settings set = db.settings.Find(User.Identity.Name);
            List<ImagesModel> photos = new List<ImagesModel>();
            FacebookController fbcontroller = new FacebookController();
            List<Images> posts = fbcontroller.GetPhoto(set.FBuserid, set.FBidentification);
            foreach (Images post in posts)
            {
                ImagesModel flm = new ImagesModel();
                flm.id = post.getId();
                flm.url = post.getURL();
                photos.Add(flm);
            }
            return View(photos);
        }

        public ActionResult PageFeedComments()
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

        public ActionResult ViewComments(string id)
        {
            Settings set = db.settings.Find(User.Identity.Name);
            if (id == null)
            {
                id = Session["id"].ToString();
            }
            else
            {
                Session["id"] = id;
            }
            List<CommentsModel> comments = new List<CommentsModel>();
            FacebookController fbcontroller = new FacebookController();
            List<Comments> posts = fbcontroller.GetComments(id, set.FBuserid, set.FBidentification);
            foreach (Comments post in posts)
            {
                CommentsModel cm = new CommentsModel();
                cm.id = post.getId();
                cm.Date = post.getTime();
                cm.message = post.getMessage();
                comments.Add(cm);
            }
            return View(comments);
        }

        public ActionResult AddComment(string message)
        {
            Settings set = db.settings.Find(User.Identity.Name);
            string id = Session["id"].ToString();
            FacebookController fbcontroller = new FacebookController();
            fbcontroller.SetComment(id,message, set.FBuserid, set.FBidentification);
            Session["id"] = id;
            return RedirectToAction("ViewComments", "FB", id);
        }

        public ActionResult ProfilePage()
        {
            Settings set = db.settings.Find(User.Identity.Name);
            List<string> perm = getPerm(set);
            FacebookController fbcontroller = new FacebookController();
            profile posts = fbcontroller.GetProfile(set.FBuserid, perm, set.FBidentification);

            ProfileModel pm = new ProfileModel();
            pm.id = posts.getId();
            pm.birthday = posts.getbirthday();
            pm.first_name = posts.getfirst_name();
            pm.last_name = posts.getlast_name();
            pm.hometown = posts.gethometown();
            pm.quotes = posts.getquotes();
            pm.likes = posts.getlikes();

            return View(pm);
        }


        public List<string> getPerm(Settings set)
        {
            List<string> perm = new List<string>();
            if (set.hometownperm == true)
            {
                perm.Add("hometown");
            }
            if (set.likesperm == true)
            {
                perm.Add("likes");
            }
            if (set.fnameperm == true)
            {
                perm.Add("first_name");
            }
            if (set.lnameperm == true)
            {
                perm.Add("last_name");
            }
            if (set.birthdayperm == true)
            {
                perm.Add("birthday");
            }
            if (set.quotesperm == true)
            {
                perm.Add("quotes");
            }
            return perm;
        }
    }
}