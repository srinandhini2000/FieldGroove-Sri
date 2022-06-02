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
            if (Session["Password"] != null)
            {
                var leadlist = _leadDAL.Show_data();
                return View(leadlist);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }



        }
       
          public ActionResult NewPage(int Id)
            {
                var customer = _leadDAL.GetCustomers().Find(x => x.Id.Equals(Id));
                return View(customer);

            }

    
        public ActionResult DeleteCustomer(int Id)
        {
            try
            {
                int result = _leadDAL.DeleteCustomer(Id);
                if (result == 1)
                {
                    ViewBag.Message = "Customer Deleted Successfully";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.Message = "Unsucessfull";
                    ModelState.Clear();
                }

                return RedirectToAction("Leads");
            }
            catch
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult UpdateCustomer(Lead objCustomer)
        {
            if (ModelState.IsValid) //checking model is valid or not    
            {
                DAL objDB = new DAL(); //calling class DBdata    
                string result = objDB.UpdateData(objCustomer);
                TempData["result2"] = result;
                ModelState.Clear(); //clearing model    
                return RedirectToAction("Leads");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }
        public JsonResult EditCustomer(int? Id)
        {
            var customer = _leadDAL.GetCustomers().Find(x => x.Id.Equals(Id));
            return Json(customer, JsonRequestBehavior.AllowGet);
        }
       

    }
 


}
