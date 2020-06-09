using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SN_Aggregator_App.Models
{
    public class PageFeedModel
    {
        public string datecreated { get; set; }
        public string id { get; set; }
        public string message { get; set; }
    }

    public class FeedLikesModel
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class ImagesModel
    {
        public string id { get; set; }
        public string url { get; set; }
    }

    public class CommentsModel
    {
        public string id { get; set; }
        public string message { get; set; }
        public string Date { get; set; }
    }

    public class ProfileModel
    {
        public string id { get; set; }
        public string birthday { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string hometown { get; set; }
        public string quotes { get; set; }
        public List<string> likes { get; set; }
    }
}