using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SN_Aggregator_App.API.POCO
{
    public class Images
    {
        private string picture;
        private string id;

        public Images(string id, string picture)
        {
            this.picture = picture;
            this.id = id;
        }

        public string getURL()
        {
            return picture;
        }

        public string getId()
        {
            return id;
        }
    }
}