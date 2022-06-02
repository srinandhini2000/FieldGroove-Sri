using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoginJwt.Models;

namespace LoginJwt.Controllers
{
    [Authorize]
    public class AppController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(LoginRequest request)
        {
            if (request?.UserName == "admin" && request?.Password == "admin")
            {
                var token = JwtHelper.CreateJwtToken(request);
                return Ok(new { success = true, jwt = token });
            }
            return Ok(new { success = false, msg = "Invalid cred" });

        }
        [HttpGet]
        [Route("home")]
        public IHttpActionResult Home()
        {
            return Ok("home");
        }
        [Authorize(Roles="admin")]
        [HttpGet]
        [Route("admin")]
        public IHttpActionResult Admin()
        {
            return Ok("admin");
        }
    }
}
