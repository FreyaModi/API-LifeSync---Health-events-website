using System;

namespace lifesync.Models
{
    public class DonEventsCity
    {
        public string Event_name { get; set; }

        public DateTime Date_from { get; set; }
        public DateTime? Date_to { get; set; }
        public TimeSpan Duration_from { get; set; }
        public TimeSpan Duration_to { get; set; }
        public DateTime Event_deadline { get; set; }
        public string Cover_pic { get; set; }
        public string Event_city { get; set; }
        public string Event_area { get; set; }
        public string Event_type { get; set; }
    }
}
