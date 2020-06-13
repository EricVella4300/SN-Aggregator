using SN_Aggregator_App.API.Endpoints;
using SN_Aggregator_App.API.Models;
using SN_Aggregator_App.API.POCO;
using System.Collections.Generic;
using WeatherWebClient.JSONParser;

namespace SN_Aggregator_App.API.Controller
{
    public class FacebookController : Controller
    {
        private Facebookendpoint facebookendpoint;

        public FacebookController() : base()
        {
            this.facebookendpoint = new Facebookendpoint();
        }

        private string GetPageAccessToken(string userid, string usertoken)
        {
            string Token = "";

            string response = getResponse(facebookendpoint.getPageAccessToken(userid, usertoken));

            System.Diagnostics.Debug.WriteLine(response);

            using (JSONParser<FacebookAPIPageAccessToken> jsonParser = new JSONParser<FacebookAPIPageAccessToken>())
            {
                FacebookAPIPageAccessToken facebookAPIPageAccessToken = new FacebookAPIPageAccessToken();
                facebookAPIPageAccessToken = (FacebookAPIPageAccessToken)jsonParser.parse(response);

                foreach (token data in facebookAPIPageAccessToken.data)
                {
                    if (data.name == "Eric's Distributed Assignment Page")
                    {
                        Token = data.access_token;
                    }
                }
            }

            return Token;
        }

        public List<FeedPost> GetPageFeed(string Token)
        {
            List<FeedPost> posts = new List<FeedPost>();

            string response = getResponse(facebookendpoint.getPageFeed(Token));

            System.Diagnostics.Debug.WriteLine(response);

            using (JSONParser<FacebookAPIPageFeed> jsonParser = new JSONParser<FacebookAPIPageFeed>())
            {
                FacebookAPIPageFeed facebookAPIPageFeeds = new FacebookAPIPageFeed();
                facebookAPIPageFeeds = (FacebookAPIPageFeed)jsonParser.parse(response);

                foreach (Data data in facebookAPIPageFeeds.data)
                {
                    posts.Add(new FeedPost(data.created_time, data.message, data.id));
                }
            }
            return posts;
        }

        public void SetPageFeed(string msg, string userid, string usertoken)
        {
            string response = PostResponse(facebookendpoint.SetPageFeed(msg, GetPageAccessToken(userid, usertoken)));

            System.Diagnostics.Debug.WriteLine(response);
        }

        public List<PostLikes> GetObjectsLikes(string Object_id, string user_id, string userToken)
        {
            List<PostLikes> likes = new List<PostLikes>();

            string response = getResponse(facebookendpoint.getLikesofPageFeed(Object_id, GetPageAccessToken(user_id, userToken)));

            System.Diagnostics.Debug.WriteLine(response);

            using (JSONParser<FaceBookAPIFeedLikes> jsonParser = new JSONParser<FaceBookAPIFeedLikes>())
            {
                FaceBookAPIFeedLikes facebookAPIFeedsLikes = new FaceBookAPIFeedLikes();
                facebookAPIFeedsLikes = (FaceBookAPIFeedLikes)jsonParser.parse(response);

                foreach (Likes data in facebookAPIFeedsLikes.data)
                {
                    likes.Add(new PostLikes(data.id, data.name));
                }
            }

            return likes;
        }

        public List<Images> GetPhoto(string user_id, string userToken)
        {
            List<Images> photos = new List<Images>();

            string response = getResponse(facebookendpoint.getimages(GetPageAccessToken(user_id, userToken)));

            System.Diagnostics.Debug.WriteLine(response);

            using (JSONParser<FacebookAPIPhoto> jsonParser = new JSONParser<FacebookAPIPhoto>())
            {
                FacebookAPIPhoto FacebookAPIPhoto = new FacebookAPIPhoto();
                FacebookAPIPhoto = (FacebookAPIPhoto)jsonParser.parse(response);

                foreach (photo data in FacebookAPIPhoto.data)
                {
                    photos.Add(new Images(data.id, data.picture));
                }
            }

            return photos;
        }

        public List<Comments> GetComments(string Post_id, string user_id, string userToken)
        {
            List<Comments> comments = new List<Comments>();

            string response = getResponse(facebookendpoint.getcomment(Post_id, GetPageAccessToken(user_id, userToken)));

            System.Diagnostics.Debug.WriteLine(response);

            using (JSONParser<FacebookAPIFeedComment> jsonParser = new JSONParser<FacebookAPIFeedComment>())
            {
                FacebookAPIFeedComment FacebookAPIPhoto = new FacebookAPIFeedComment();
                FacebookAPIPhoto = (FacebookAPIFeedComment)jsonParser.parse(response);

                foreach (comments data in FacebookAPIPhoto.data)
                {
                    comments.Add(new Comments(data.id, data.created_time, data.message));
                }
            }

            return comments;
        }

        public void SetComment(string id,string msg, string user_id, string userToken)
        {
            string response = PostResponse(facebookendpoint.addcomment(id, msg, GetPageAccessToken(user_id, userToken)));

            System.Diagnostics.Debug.WriteLine(response);
        }

        public profile GetProfile(string userId, List<string> perm, string token)
        {
            profile prof;

            string response = getResponse(facebookendpoint.GetProfile(userId, perm, token));

            System.Diagnostics.Debug.WriteLine(response);

            using (JSONParser<FacebookAPIProfile> jsonParser = new JSONParser<FacebookAPIProfile>())
            {
                FacebookAPIProfile facebookAPIProfile = new FacebookAPIProfile();
                facebookAPIProfile = (FacebookAPIProfile)jsonParser.parse(response);

                List<string> likedpg = new List<string>();

                prof = new profile();
                try
                {
                    prof.setbirthday(facebookAPIProfile.birthday);
                }
                catch
                {
                    //nothing
                }
                try
                {
                    prof.setid(facebookAPIProfile.id);
                }
                catch
                {
                    //nothing
                }
                try
                {
                    prof.setquotes(facebookAPIProfile.quotes);
                }
                catch
                {
                    //nothing
                }
                try
                {
                    prof.setfirst_name(facebookAPIProfile.first_name);
                }
                catch
                {
                    //nothing
                }
                try
                {
                    prof.setlast_name(facebookAPIProfile.last_name);
                }
                catch
                {
                    //nothing
                }
                try
                {
                    foreach (Liked like in facebookAPIProfile.likes.data)
                    {
                        likedpg.Add(like.name);
                    }
                    prof.setlikes(likedpg);
                }
                catch
                {
                    //nothing
                }
                try
                {
                    prof.sethometown(facebookAPIProfile.hometown.name);
                }
                catch
                {
                    //nothing
                }
            }

            return prof;
        }
    }
}