using System.Collections.Generic;
using System.Linq;
using LoginAPI.Controllers;
using LoginAPI.Models;
using NUnit.Framework;
using Umbraco.Core.Services.Implement;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace Test_Api
{
    public class Tests
    {
       

        [TestMethod]  
        public void Test1_Works()
        {
           
          
            var controller = new UserDetailsController();
            User us1 = new User();
            us1.Firstname = "Srinandhini";
            var res = controller.InsertProduct(us1 );

            
            Assert.AreEqual("Srinandhini", us1.Firstname);

        }

       
    }
}