using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SN_Aggregator_App.API.Models
{
    [DataContract]
    class FacebookAPIPageAccessToken
    {
        [DataMember]
        public List<token> data;
    }
    [DataContract]
    class token
    {
        [DataMember]
        public string access_token;
        [DataMember]
        public string name;
    }
}