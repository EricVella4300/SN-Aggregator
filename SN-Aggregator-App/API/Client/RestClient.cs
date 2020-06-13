using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace SN_Aggregator_App.API.Client
{
    public enum httpVerb
    {
        GET,
        POST
    }

    public class RestClient
    {
        public string endpoint { get; set; }
        public httpVerb httpMethod { get; set; }

        public string GetRequest()
        {
            httpMethod = httpVerb.GET;

            string strResponseValue = string.Empty;

            HttpWebRequest myrequest = (HttpWebRequest)HttpWebRequest.Create(endpoint);

            myrequest.Method = httpMethod.ToString();

            using (HttpWebResponse response = (HttpWebResponse)myrequest.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException($"Error Code : {response.StatusCode}");
                }

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }

            return strResponseValue;
        }

        public string PostRequest()
        {
            httpMethod = httpVerb.POST;

            string strResponseValue = string.Empty;

            HttpWebRequest myrequest = (HttpWebRequest)HttpWebRequest.Create(endpoint);

            myrequest.Method = httpMethod.ToString();

            using (HttpWebResponse response = (HttpWebResponse)myrequest.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException($"Error Code : {response.StatusCode}");
                }

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }

            return strResponseValue;
        }
    }
}