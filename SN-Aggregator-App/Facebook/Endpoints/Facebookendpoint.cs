using System.Collections.Generic;
using System.Text;

namespace SN_Aggregator_App.Facebook.Endpoints
{
    public class Facebookendpoint
    {
        private string baseEndpoint = "https://graph.facebook.com/v7.0";
        private string pageId = "111932443877979";
        private string pageAccessToken = "EAAmOdww8QdkBAHnpgeLwVSgxtmceAYi5WZBzX7sAqG9HK5ltOTEqD9bX0W0Nxo301UWpt0zRmTFBgnr2FYDzp76Nq4x9fZCn2MB8CkJYUBrHJeYAZCx9YZA90qVnKEpOwulGVommtTdyzb35ml4N7gzwnZCByomzozUtWJcxPHa6ZANsZCx1KnVrOyZCZBbEb8lsh6K5YTIxsuQZDZD";

        public string getPageFeed(string UserToken)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("/" + pageId);
            stringBuilder.Append("/feed");
            stringBuilder.Append("?access_token=" + UserToken);

            return stringBuilder.ToString();
        }

        public string SetPageFeed(string message)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("/" + pageId);
            stringBuilder.Append("/feed");
            stringBuilder.Append("?message=" + message);
            stringBuilder.Append("&access_token=" + pageAccessToken);

            return stringBuilder.ToString();
        }

        public string getLikesofPageFeed(string objectId)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("/" + objectId);
            stringBuilder.Append("/likes");
            stringBuilder.Append("?access_token=" + pageAccessToken);

            return stringBuilder.ToString();
        }

        public string getimages()
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("/" + pageId);
            stringBuilder.Append("/photos");
            stringBuilder.Append("/uploaded");
            stringBuilder.Append("?fields=picture");
            stringBuilder.Append("&access_token=" + pageAccessToken);

            return stringBuilder.ToString();
        }

        public string getcomment(string post_id)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("/" + post_id);
            stringBuilder.Append("/comments");
            stringBuilder.Append("?access_token=" + pageAccessToken);

            return stringBuilder.ToString();
        }

        public string addcomment(string post_id, string message)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("/" + post_id);
            stringBuilder.Append("/comments");
            stringBuilder.Append("?message=" + message);
            stringBuilder.Append("&access_token=" + pageAccessToken);

            return stringBuilder.ToString();
        }

        public string GetProfile(string userid,List<string> permissions, string usertoken)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("/" + userid);
            stringBuilder.Append("?fields=");
            foreach (string str in permissions)
            {
                stringBuilder.Append(str+",");
            }
            stringBuilder.Length = stringBuilder.Length - 1;
            stringBuilder.Append("&access_token=" + usertoken);
            return stringBuilder.ToString();
        }
    }
}