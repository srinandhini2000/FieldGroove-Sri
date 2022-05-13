using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginAPI.Models
{
    public class Lead
    {
        public string Name { get; set; }
        public string Project_Name { get; set; }
        public string Status { get; set; }
        public string Added { get; set; }
        public string Type { get; set; }



        public string Contact { get; set; }
        public string Action { get; set; }
        public string Assignee { get; set; }
        public string Bid_Date { get; set; }
    }
}