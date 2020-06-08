using System.Text;

namespace SN_Aggregator_App.Facebook.Endpoints
{
    public class Facebookendpoint
    {
        private string baseEndpoint = "https://graph.facebook.com/v7.0";
        private string pageId = "111932443877979";
        private string pageAccessToken = "EAAmOdww8QdkBANEiZAUMxwjoqakiVnFTBI4njBDmWTMMQxEW70Q7xRpRVUz2SfTySSHQAFkkmRMFE1wTy0UJuSKoI9DIoA5BC6rprSQNfbpg3AFbi3ZAg0RaSv6oSZCNiIL7xX4NkXiLWwoOboVbCYYWsZA0Sl44i6ha2Rbon2LvegvMlHvXxnXOZCpjoZCuhmK0ZATp2nqUwZDZD";

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
    }
}