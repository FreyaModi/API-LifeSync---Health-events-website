using System;

namespace lifesync.Models
{
    public class OpenEventModel
    {

        public int Event_id { get; set; }   
        public string Event_name { get; set;}
        public string Event_org { get; set;}
        public string Event_address { get; set;}
        public string Event_desc { get; set;}
        public string Event_area{ get; set;}
        public string Event_city { get; set;}
        public DateTime Date_from { get; set;}
        public DateTime? Date_to { get; set;}
        public TimeSpan Duration_from { get; set;}
        public TimeSpan Duration_to { get; set;}
    }
}
