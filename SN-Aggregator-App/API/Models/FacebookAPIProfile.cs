using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SN_Aggregator_App.API.Models
{
    [DataContract]
    class FacebookAPIProfile
    {
        [DataMember]
        public string quotes;
        [DataMember]
        public string birthday;
        [DataMember]
        public string first_name;
        [DataMember]
        public string last_name;
        [DataMember]
        public string id;
        [DataMember]
        public pglikes likes;
        [DataMember]
        public homet hometown;
    }

    [DataContract]
    class homet
    {
        [DataMember]
        public string name;
    }

    [DataContract]
    class pglikes
    {
        [DataMember]
        public List<Liked> data;
    }

    [DataContract]
    class Liked
    {
        [DataMember]
        public string name;
    }
}