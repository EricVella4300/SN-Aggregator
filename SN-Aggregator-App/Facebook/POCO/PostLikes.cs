using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SN_Aggregator_App.Facebook.POCO
{
    public class PostLikes
    {
        private string id;
        private string name;

        public PostLikes(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public string getName()
        {
            return name;
        }

        public string getId()
        {
            return id;
        }
    }
}