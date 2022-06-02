using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginAPI.Models
{
    public class Login
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is requierd")]
        
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter the Password!")]
        [Display(Name = "Enter password...")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
    }
}