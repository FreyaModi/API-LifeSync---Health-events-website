using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace lifesync.Models
{
    public class UserContactModel
    {
        public int User_contact_id { get; set; }
        public int User_id { get; set; }
        public string User_contactno { get; set; }
    }
}
