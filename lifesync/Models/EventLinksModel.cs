using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace lifesync.Models
{
    public class EventLinksModel
    {
        public int Event_links_id { get; set; }
        public  int Event_id{ get; set; }
   
        public string Event_links { get; set; }
    }
}
