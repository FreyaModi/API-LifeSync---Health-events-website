using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace lifesync.Models
{
    public class EventContactModel
    {
        public int Event_contact_id { get; set; }
        public  int Event_id { get; set; }
        public string Event_contactno { get; set; }
    }
}
