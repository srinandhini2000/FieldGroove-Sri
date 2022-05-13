using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginAPI.Models
{
    public class Login
    {
       [Required(ErrorMessage="Please enter the Email!")]
       [Display(Name ="Enter email...")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter the Password!")]
        [Display(Name = "Enter password...")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
    }
}