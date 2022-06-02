using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using LoginAPI;
using LoginAPI.Controllers;



namespace Test_LoginApi
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Index()
        {
            //arrange
            HomeController con = new HomeController();
            //act
            ViewResult result = con.Index() as ViewResult;
            //assert
            Assert.IsNotNull(result);
        }
    }
}
