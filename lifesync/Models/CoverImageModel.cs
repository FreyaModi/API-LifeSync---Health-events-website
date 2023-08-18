using Microsoft.AspNetCore.Http;

namespace lifesync.Models
{
    public class CoverImageModel
    {
        public IFormFile file { get; set; }
        public int Event_id { get; set; }
        
    }
}
