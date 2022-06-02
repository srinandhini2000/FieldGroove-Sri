using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.JScript;

namespace WebappJWT
{
    public class TokenManager
    {
        private static string Secret = Guid.NewGuid().ToString();
        public static string GenerateToken(string userName)
        {
            byte[] key = Convert.ToBase64String(Secret);

        }
    }
}