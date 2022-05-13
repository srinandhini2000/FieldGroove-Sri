using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginAPI.Models;

namespace LoginAPI.Controllers
{
    public class LeadsController : Controller
    {
        // GET: Leads
        DAL _leadDAL = new DAL();
       
       
        public ActionResult Leads()
        {
            var leadlist = _leadDAL.Show_data();
            return View(leadlist);
        }
        public ActionResult Opportunity()
        {
            return View();
        }
    }
}