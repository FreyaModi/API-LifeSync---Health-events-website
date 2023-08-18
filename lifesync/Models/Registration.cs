using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace lifesync.Models
{
    public class Registration
    {

        public virtual int Log_id { get; set; }
        public virtual int User_id { get; set; }
        public DateTime Login_time { get; set; }
        public DateTime Logout_time { get; set; }
    }
}
