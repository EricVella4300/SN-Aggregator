using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SN_Aggregator_App.Facebook.Models
{
    [DataContract]
    class FacebookAPIPhoto
    {
        [DataMember]
        public List<photo> data;       
    }

    [DataContract]
    class photo
    {
        [DataMember]
        public string id;
        [DataMember]
        public string picture;
    }
}