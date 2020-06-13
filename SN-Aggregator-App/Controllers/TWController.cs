using SN_Aggregator_App.API.Controller;
using SN_Aggregator_App.API.POCO;
using SN_Aggregator_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SN_Aggregator_App.Controllers
{
    public class TWController : System.Web.Mvc.Controller
    {
        public ActionResult MentionsDisplay()
        {
            return View();
        }
    }
}