using System;
using System.Web.Mvc;
using LoginAPI.Controllers;
using LoginAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest_Login
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Check_insert()
        {
            //Arrange initialize the object 
            HomeController home = new HomeController();

            //Act
             ActionResult res = home.Index();
            //Assert
            Assert.IsNotNull(res);
        }
    }
}
