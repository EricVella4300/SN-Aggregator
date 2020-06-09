using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SN_Aggregator_App.Facebook.POCO
{
    public class Comments
    {
        private string Created_time;
        private string id;
        private string Message;

        public Comments(string id, string Created_time, string Message)
        {
            this.Created_time = Created_time;
            this.id = id;
            this.Message = Message;
        }

        public string getTime()
        {
            return Created_time;
        }

        public string getMessage()
        {
            return Message;
        }

        public string getId()
        {
            return id;
        }
    }
}