using System;
using LoginAPI.Controllers;
using LoginAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace UnitTest_Sample
{
    [TestClass]
    public class UnitTest1
    {
       
        [TestMethod]
       
        public void AddApiRedirect()
            {
            LoginAPI.Models.User person =new LoginAPI.Models.User();


            //Act
            Assert.AreEqual(null, person.Firstname);
          
  
            /* var controller = new HomeController();

             // Act
             var result = controller.Index() as ViewResult;
             LoginAPI.Models.Login person =
 (LoginAPI.Models.Login)result.Model;

             // Assert*/
            /* Assert.AreEqual("Sheo", person.Email,null);*/
        }
         
    }
}
