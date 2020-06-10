using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SN_Aggregator_App.Models
{
    public class Settings
    {
        [Key]
        public string user_email { get; set; }
        public string FBidentification { get; set; }
        public string FBuserid { get; set; }
        public string TwitterIdentification { get; set; }
        public bool fnameperm { get; set; }
        public bool lnameperm { get; set; }
        public bool birthdayperm { get; set; }
        public bool hometownperm { get; set; }
        public bool quotesperm { get; set; }
        public bool likesperm { get; set; }
        public string Twitteruserid { get; set; }
    }
}