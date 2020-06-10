using SN_Aggregator_App.Facebook.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SN_Aggregator_App.Facebook.Controller
{
    public class TwitterController : Controller
    {
        private TwitterEndpoints twitterEndpoint;

        public TwitterController() : base()
        {
            this.twitterEndpoint = new TwitterEndpoints();
        }

        //public List<FeedPost> GetPageFeed(string Token)
        //{
        //    List<FeedPost> posts = new List<FeedPost>();

        //    string response = getResponse(twitterEndpoint.GetFollowers(Token));

        //    System.Diagnostics.Debug.WriteLine(response);

        //    using (JSONParser<FacebookAPIPageFeed> jsonParser = new JSONParser<FacebookAPIPageFeed>())
        //    {
        //        FacebookAPIPageFeed facebookAPIPageFeeds = new FacebookAPIPageFeed();
        //        facebookAPIPageFeeds = (FacebookAPIPageFeed)jsonParser.parse(response);

        //        foreach (Data data in facebookAPIPageFeeds.data)
        //        {
        //            posts.Add(new FeedPost(data.created_time, data.message, data.id));
        //        }
        //    }
        //    return posts;
        //}
    }
}