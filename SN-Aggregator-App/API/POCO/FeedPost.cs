using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SN_Aggregator_App.API.POCO
{
    public class FeedPost
    {
        private string dateTime;
        private string message;
        private string id;

        public FeedPost(string dateTime, string message, string id)
        {
            this.dateTime = dateTime;
            this.message = message;
            this.id = id;
        }

        public string getDateTime()
        {
            return dateTime;
        }

        public string getMessage()
        {
            return message;
        }

        public string getId()
        {
            return id;
        }
    }
}