using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;
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
        public ActionResult Signup()
        {
            return View();
        }
        public JsonResult InsertProduct(User user)
        {
            
            SqlCommand cmd = new SqlCommand("Select * from tbl_User where Email= @Email", con);
            
            cmd.Parameters.AddWithValue("@Email",user.Email);

            System.Diagnostics.Debug.WriteLine(user.Email);



            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
           
                if (dr.HasRows == true)
                {
                /* MessageBox.Show("Email = " + dr[4].ToString() + " Already exist");*/

                ViewBag.Message = "Email is already exist";
               

                }
                else
                {

                    string msg = string.Empty;
                con.Close();

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
                    catch (Exception ex)
                    {
                        /*msg = "Please Enter Valid Data";
                        return Json(msg, JsonRequestBehavior.AllowGet);*/
                    msg = ex.Message;
                    return Json(msg, JsonRequestBehavior.AllowGet);

                }
                

            }

            
            return Json(ViewBag.Message);
        }
        public JsonResult InsertOpportunity(Opportunity opp)
        {
            string msg = string.Empty;
            try
            {



                SqlCommand command = new SqlCommand("[dbo].[SP_Opportunitiy]", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Customer", opp.Customer);
                command.Parameters.AddWithValue("@Name_Number", opp.Name_Number);
                command.Parameters.AddWithValue("@Address", opp.Address);
                command.Parameters.AddWithValue("@Salesperson", opp.Salesperson);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                msg = "Data Inserted";
                return Json(msg, JsonRequestBehavior.AllowGet);




            }
            catch (Exception ex)
            {
                /* msg = "Please Enter Valid Data";
                 return Json(msg, JsonRequestBehavior.AllowGet);*/
                 msg = ex.Message;
                 return Json(msg, JsonRequestBehavior.AllowGet);



            }
        }
    }
}

