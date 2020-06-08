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
        public string TwitterIdentification { get; set; }
    }
}