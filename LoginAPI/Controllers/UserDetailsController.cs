using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginAPI.Controllers
{
    public class UserDetailsController : Controller
    {
        // GET: UserDetails

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult InsertProduct(User user)
        {
            string msg = string.Empty;
            try
            {
               
                   SqlCommand command = new SqlCommand("sp_insertRecords", con);
                command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Firstname", user.Firstname);
                command.Parameters.AddWithValue("@Lastname", user.Lastname);
                command.Parameters.AddWithValue("@Companyname", user.Companyname);
                command.Parameters.AddWithValue("@Phone", user.Phone);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Passwordagain", user.Passwordagain);
                command.Parameters.AddWithValue("@Timezone", user.Timezone);
                command.Parameters.AddWithValue("@Streetaddress_1", user.Streetaddress_1);
                command.Parameters.AddWithValue("@Streetaddress_2", user.Streetaddress_2);

                command.Parameters.AddWithValue("@City", user.City);
                command.Parameters.AddWithValue("@State", user.State);
                command.Parameters.AddWithValue("@Zip", user.Zip);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                msg = "Data Inserted";
                return Json(msg, JsonRequestBehavior.AllowGet);
               
            }
            catch (Exception )
            {
                msg = "Please Enter Valid Data";
                return Json(msg, JsonRequestBehavior.AllowGet);

            }
        }
    }
}

