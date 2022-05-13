using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginAPI.Models
{
    public class User
    {
        [Key]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Companyname { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Passwordagain { get; set; }
        [Required]
        public string Timezone { get; set; }
         [Required]
        public string Streetaddress_1 { get; set; }
        [Required]
        public string Streetaddress_2 { get; set; }
        [Required]
        public string City{ get; set; }
        [Required]
        public string State{ get; set; }
        [Required]
        public string Zip { get; set; }

    }

}