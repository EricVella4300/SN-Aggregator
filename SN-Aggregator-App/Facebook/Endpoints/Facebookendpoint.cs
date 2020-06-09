using System.Text;

namespace SN_Aggregator_App.Facebook.Endpoints
{
    public class Facebookendpoint
    {
        private string baseEndpoint = "https://graph.facebook.com/v7.0";
        private string pageId = "111932443877979";
        private string pageAccessToken = "EAAmOdww8QdkBAKqZCtiwZAveO3KTmaIgTEbPgQQZAVilk5elH5VBqdDysySWYBunnxYpziCjmIFdhaExkIODxQYKBWtZCF6RWZAgvT4ZBOWgqqXTduZAYpUbKzZAREO37k8PEygkx3CnI8H6zZAz5dIUbOaMFfNOPL2VaOJxqqfoaJDuuR8fVWoanwyylRA5xSnwZD";

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

    }
}