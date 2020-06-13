using System.Collections.Generic;
using System.Text;

namespace SN_Aggregator_App.API.Endpoints
{
    public class Facebookendpoint
    {
        private string baseEndpoint = "https://graph.facebook.com/v7.0";
        private string pageId = "111932443877979";

        public string getPageAccessToken(string user_id, string UserAT)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("/" + user_id);
            stringBuilder.Append("/accounts");
            stringBuilder.Append("?access_token=" + UserAT);

            return stringBuilder.ToString();
        }

        public string getPageFeed(string UserToken)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("/" + pageId);
            stringBuilder.Append("/feed");
            stringBuilder.Append("?access_token=" + UserToken);

            return stringBuilder.ToString();
        }

        public string SetPageFeed(string message, string pageAccessToken)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("/" + pageId);
            stringBuilder.Append("/feed");
            stringBuilder.Append("?message=" + message);
            stringBuilder.Append("&access_token=" + pageAccessToken);

            return stringBuilder.ToString();
        }

        public string getLikesofPageFeed(string objectId, string pageAccessToken)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("/" + objectId);
            stringBuilder.Append("/likes");
            stringBuilder.Append("?access_token=" + pageAccessToken);

            return stringBuilder.ToString();
        }

        public string getimages(string pageAccessToken)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("/" + pageId);
            stringBuilder.Append("/photos");
            stringBuilder.Append("/uploaded");
            stringBuilder.Append("?fields=picture");
            stringBuilder.Append("&access_token=" + pageAccessToken);

            return stringBuilder.ToString();
        }

        public string getcomment(string post_id, string pageAccessToken)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("/" + post_id);
            stringBuilder.Append("/comments");
            stringBuilder.Append("?access_token=" + pageAccessToken);

            return stringBuilder.ToString();
        }

        public string addcomment(string post_id, string message, string pageAccessToken)
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