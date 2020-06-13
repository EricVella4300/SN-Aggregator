using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SN_Aggregator_App.API.Models
{
    [DataContract]
    class FacebookAPIFeedComment
    {
        [DataMember]
        public List<comments> data;
    }
    [DataContract]
    class comments
    {
        [DataMember]
        public string created_time;
        [DataMember]
        public string id;
        [DataMember]
        public string message;
    }
}