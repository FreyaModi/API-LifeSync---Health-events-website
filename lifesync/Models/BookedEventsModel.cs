using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace lifesync.Models
{
    public class BookedEventsModel
    {
        public int Booked_events_id { get; set; }
        public int Event_id { get; set; }

        public int User_id { get; set; }
    }
}