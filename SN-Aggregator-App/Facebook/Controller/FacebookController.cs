using SN_Aggregator_App.Facebook.Endpoints;
using SN_Aggregator_App.Facebook.Models;
using SN_Aggregator_App.Facebook.POCO;
using System.Collections.Generic;
using WeatherWebClient.JSONParser;

namespace SN_Aggregator_App.Facebook.Controller
{
    public class FacebookController : Controller
    {
        private Facebookendpoint facebookendpoint;

        public FacebookController() : base()
        {
            this.facebookendpoint = new Facebookendpoint();
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

        public void SetPageFeed(string msg)
        {
            string response = PostResponse(facebookendpoint.SetPageFeed(msg));

            System.Diagnostics.Debug.WriteLine(response);
        }

        public List<PostLikes> GetObjectsLikes(string Object_id)
        {
            List<PostLikes> likes = new List<PostLikes>();

            string response = getResponse(facebookendpoint.getLikesofPageFeed(Object_id));

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

        public List<Images> GetPhoto()
        {
            List<Images> photos = new List<Images>();

            string response = getResponse(facebookendpoint.getimages());

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

        public List<Comments> GetComments(string Post_id)
        {
            List<Comments> comments = new List<Comments>();

            string response = getResponse(facebookendpoint.getcomment(Post_id));

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

        public void SetComment(string id,string msg)
        {
            string response = PostResponse(facebookendpoint.addcomment(id, msg));

            System.Diagnostics.Debug.WriteLine(response);
        }
    }
}