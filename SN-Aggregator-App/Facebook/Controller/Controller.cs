using SN_Aggregator_App.Facebook.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SN_Aggregator_App.Facebook.Controller
{
    public class Controller
    {
        protected RestClient client;

        public Controller()
        {
            client = new RestClient();
        }

        protected string getResponse(string endpoint)
        {
            client.endpoint = endpoint;
            return client.GetRequest();
        }
        protected string PostResponse(string endpoint)
        {
            client.endpoint = endpoint;
            return client.PostRequest();
        }
    }
}