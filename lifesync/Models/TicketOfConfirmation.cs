using System;

namespace lifesync.Models
{
    public class TicketOfConfirmation
    {
        public string Event_name { get; set; }
        public int User_id { get; set; }
        public int Event_id { get; set; }
        public string User_name  { get; set; }
        public string Event_org { get; set; }
        public int Age { get; set; }
        public DateTime Date_from { get; set; }
        public DateTime? Date_to { get; set; }
        public TimeSpan Duration_from { get; set; }
        public TimeSpan Duration_to { get; set; }
   
        public string Event_city { get; set; }
        public string Event_area { get; set; }
   
    }
}
