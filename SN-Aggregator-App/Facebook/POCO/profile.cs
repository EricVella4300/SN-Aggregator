using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SN_Aggregator_App.Facebook.POCO
{
    public class profile
    {
        private string quotes;
        private string id;
        private string birthday;
        private string first_name;
        private string last_name;
        private string hometown;
        private List<string> likes;

        public profile()
        {
            quotes = null;
            id = null;
            birthday = null;
            first_name = null;
            last_name = null;
            hometown = null;
            likes = null;
        }

        public void setquotes(string str)
        {
            quotes = str;
        }

        public void setbirthday(string str)
        {
            birthday = str;
        }

        public void setfirst_name(string str)
        {
            first_name = str;
        }

        public void setlast_name(string str)
        {
            last_name = str;
        }

        public void sethometown(string str)
        {
            hometown = str;
        }

        public void setlikes(List<string> str)
        {
            likes = str;
        }

        public void setid(string str)
        {
            id = str;
        }

        public string getquotes()
        {
            return quotes;
        }

        public string getbirthday()
        {
            return birthday;
        }

        public string getfirst_name()
        {
            return first_name;
        }

        public string getlast_name()
        {
            return last_name;
        }

        public string gethometown()
        {
            return hometown;
        }

        public List<string> getlikes()
        {
            return likes;
        }

        public string getId()
        {
            return id;
        }
    }
}