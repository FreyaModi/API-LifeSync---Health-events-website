using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System;

namespace lifesync.Models
{
    public class FeedbackModel
    {
        public  int Feedback_id { get; set; }
        public int Rating { get; set; }
        public string Feedback_desc { get; set;}
        public  int Event_id{ get; set; }
        public  int User_id { get; set; }
        public DateTime Post_time { get; set; }

    }
}
