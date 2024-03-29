﻿using LoginAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using System.Web.Security;


namespace LoginAPI.Controllers
{
    public class HomeController : Controller
    {
        Models.DAL obj = new Models.DAL();
        public ActionResult Index()
        {
            
            return View();
           
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(Login login)
        {
           
            string connection = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection sql = new SqlConnection(connection);
            SqlCommand com = new SqlCommand("sp_Signin");
            sql.Open();
            com.Connection = sql;
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Email", login.Email);
            com.Parameters.AddWithValue("@Password", login.Password);
            SqlDataReader dr = com.ExecuteReader();
            if(dr.Read())
            {
                Session["Password"] = login.Password.ToString();
                Session["Email"] = login.Email.ToString();
              
                    return RedirectToAction("Leads", "Leads");
               
            }
            else
            {
                ViewData["message"] = "Login Failed.......!";
            }

            sql.Close();

            return View();
        }

        public RedirectToRouteResult Logout(object sender, EventArgs e)
        {

            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("Index");
        }



    }
}
