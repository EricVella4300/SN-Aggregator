using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SN_Aggregator_App.Facebook.Models
{
    [DataContract]
    class FaceBookAPIFeedLikes
    {
        [DataMember]
        public List<Likes> data;
    }
    [DataContract]
    class Likes
    {
        [DataMember]
        public string id;
        [DataMember]
        public string name;
    }
}