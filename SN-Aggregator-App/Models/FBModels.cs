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
}