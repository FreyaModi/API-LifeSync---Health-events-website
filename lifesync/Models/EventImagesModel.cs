using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;

namespace lifesync.Models
{
    public class EventImagesModel
    {
        public int Event_images_id { get; set; }
        public  int Event_id{ get; set; }
        public byte[] Event_img { get; set; }
        public IFormFile UploadFile { get; set; }
    }
}
