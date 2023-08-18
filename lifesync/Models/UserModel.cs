using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using System;

namespace lifesync.Models
{
    public class UserModel
    {
        public int User_id { get; set; }
        public string User_emailid { get; set; }   
        public string User_type { get; set; }
        public string User_pic { get; set; }
        public string User_name { get; set; }
        public string Org_name { get; set; }
        public string Password { get; set; }
        public DateTime? User_dob { get; set; }
        public string Gender { get; set; }
        public string User_address { get;set; }
        public string Blood_group { get; set;}
        public string User_city { get;set; }
        public string User_description { get; set;}
        public string Person_contact { get; set;}
        public int? Eve_select { get; set;}
    }
}
