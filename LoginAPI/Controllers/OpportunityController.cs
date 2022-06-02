using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginAPI.Models;

namespace LoginAPI.Controllers
{
    public class OpportunityController : Controller
    {
        // GET: Opportunity
        Dboppor dbo = new Dboppor();
        public ActionResult Index()
        {
           

            if (Session["Email"] != null)
            {
                var li = dbo.Show_data();
                return View(li);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }

      
        
    }
}
