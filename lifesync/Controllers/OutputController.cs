using lifesync.Models;
using lifesync.Repository;
using Microsoft.AspNetCore.Mvc;

namespace lifesync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutputController : Controller
    {
        private readonly IOutputRepository _outputRepository;

        public OutputController(IOutputRepository outpuRepository)
        {
            _outputRepository = outpuRepository;
        }
        [HttpGet("{Event_city}")]

        public IActionResult GetEvents([FromQuery]EventsModel EventsModel)
        {
         int eventid=_outputRepository.GetEventsByCity(EventsModel);
            if (eventid == 0)
            {
                NotFound();
            }
            return Ok(eventid);

        }
    }
}
