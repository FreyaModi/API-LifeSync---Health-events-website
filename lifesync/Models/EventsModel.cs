using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System;
using Microsoft.AspNetCore.Http;

namespace lifesync.Models
{
    public class EventsModel
    {
        public int Event_id { get; set; }
        public string Event_name { get; set;}
        public  int User_id { get; set; }
     
        public string Event_org { get; set; }
        public DateTime Date_from { get; set; }
        public DateTime? Date_to { get; set; }
        public TimeSpan Duration_from { get; set; }
        public TimeSpan Duration_to { get; set; }
        public DateTime Event_deadline { get; set; }
        public byte[] Cover_pic { get; set; }
        public IFormFile UploadFile { get; set; }
        public string Event_city { get; set; }
        public string Event_address { get; set;}
        public string Event_desc { get; set;}
        public string Event_area { get; set;}
        public int? Event_seats { get; set;}
        public string Event_type { get; set;}
        public string Sub_type { get; set; }
        public int? Event_status { get; set; }
    }
}
