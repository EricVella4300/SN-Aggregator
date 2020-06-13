using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SN_Aggregator_App.API.Models
{
    [DataContract]
    class FacebookAPIPageFeed
    {
        [DataMember]
        public List<Data> data;
    }
    [DataContract]
    class Data
    {
        [DataMember]
        public string created_time;
        [DataMember]
        public string message;
        [DataMember]
        public string id;
    }
}