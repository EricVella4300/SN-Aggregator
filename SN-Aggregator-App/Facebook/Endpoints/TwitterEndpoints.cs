using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SN_Aggregator_App.Facebook.Endpoints
{
    public class TwitterEndpoints
    {

        private string baseEndpoint = "https://api.twitter.com/1.1";
        private string pageId = "111932443877979";
        private string pageAccessToken = "EAAmOdww8QdkBAHnpgeLwVSgxtmceAYi5WZBzX7sAqG9HK5ltOTEqD9bX0W0Nxo301UWpt0zRmTFBgnr2FYDzp76Nq4x9fZCn2MB8CkJYUBrHJeYAZCx9YZA90qVnKEpOwulGVommtTdyzb35ml4N7gzwnZCByomzozUtWJcxPHa6ZANsZCx1KnVrOyZCZBbEb8lsh6K5YTIxsuQZDZD";
 

        public string GetFollowers(string username)
        {
            StringBuilder stringBuilder = new StringBuilder(baseEndpoint);
            stringBuilder.Append("/followers");
            stringBuilder.Append("/list.json");
            stringBuilder.Append("?cursor=-1");
            stringBuilder.Append("&screen_name="+username);
            stringBuilder.Append("&include_user_entities=false");

            return stringBuilder.ToString();
        }
    }
}