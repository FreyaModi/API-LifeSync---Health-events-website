using lifesync.Models;
using lifesync.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static lifesync.Repository.EventRepository;

namespace lifesync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        [HttpPost("insertuser")]
        
        public IActionResult InsertUser(UserModel userModel)
        {
        
            _eventRepository.InsertIntoUsers(userModel);
            // Retrieve the generated primary key value
            //int userId = userModel.User_id;

            // Store the userId in the session
           // HttpContext.Session.SetInt32("UserId", userId);
            return Ok();
          
        }
        [HttpPost("updateuser")]
        public IActionResult UpdatetUser(UserModel userModel)
        {
            if(HttpContext.Session != null)
            {
                int? userid = HttpContext.Session.Get("userid")?.Length > 0
              ? Convert.ToInt32(HttpContext.Session.Get("userid")[0])
              : (int?)null;
                //? userid = HttpContext.Session.GetInt32("userid") != null ? HttpContext.Session.GetInt32("userid") : null;
                if (userModel.User_id > 0)
                {
                    //userModel.User_id=userid!=null?(int)userid : 0;

                   
                    int cnt=  _eventRepository.UpdateIntoUsers(userModel);
                    if (cnt > 0)
                    {
                        return Ok("data updated successfully");
                    }
                }
            }
            return Ok("session is null");
        }
        [HttpPost("coverimg")]
        [Consumes("multipart/form-data")]
        public IActionResult CoverImage([FromForm] CoverImageModel formData)
        {
            
                  _eventRepository.CoverImage(formData);
                    
            return Ok();
        }

        [HttpPost("insertevent")]

        public IActionResult InsertEvent(  EventsModel EventsModel) 
        {

            if (HttpContext.Session != null)
               {
                int? userid = HttpContext.Session.Get("userid")?.Length > 0
              ? Convert.ToInt32(HttpContext.Session.Get("userid")[0])
              : (int?)null;
                //? userid = HttpContext.Session.GetInt32("userid") != null ? HttpContext.Session.GetInt32("userid") : null;
                if (EventsModel.User_id > 0)
                {
                    //userModel.User_id=userid!=null?(int)userid : 0;


                    int cnt = _eventRepository.InsertIntoEvents( EventsModel);
                    if (cnt > 0)
                    {
                        return Ok(cnt);
                    }
                }
            }
            return Ok("session is null");
        }
        [HttpPost("booked")]

        public IActionResult BookedEvents(BookedEventsModel BookedEventsModel)
        {
            if (HttpContext.Session != null)
            {
                int? userid = HttpContext.Session.Get("userid")?.Length > 0
         ? Convert.ToInt32(HttpContext.Session.Get("userid")[0])
         : (int?)null;
                // int? userid = HttpContext.Session.GetInt32("userid") != null ? HttpContext.Session.GetInt32("userid") : null;
                if (BookedEventsModel.User_id != null && BookedEventsModel.Event_id != null)
                {
                   // BookedEventsModel.User_id = userid != null ? (int)userid : 0;
                    int cnt = _eventRepository.InsertIntoBookedEvents(BookedEventsModel);
                    if (cnt > 0)
                    {
                        return Ok("data updated successfully");
                    }
                }
            }
            return Ok("session is null");

        }
       
                                  
        [HttpPost("logout")]
        public IActionResult LogUpdate(Registration Registration)
        {
            
            if (HttpContext.Session != null)
            {
                int? userid = HttpContext.Session.Get("userid")?.Length > 0
        ? Convert.ToInt32(HttpContext.Session.Get("userid")[0])
        : (int?)null;
                //int? userid = HttpContext.Session.GetInt32("userid") != null ? HttpContext.Session.GetInt32("userid") : null;
                if (Registration.User_id != null)
                {
                    //Registration.User_id = userid != null ? (int)userid : 0;
                    int cnt = _eventRepository.UpdateTheLogs(Registration);
                    if (cnt > 0)
                    {
                        return Ok("data updated successfully");
                    }
                }
               // var sess = HttpContext.Session.Get("userid");
            }
            return Ok("session is null");
        }

        [HttpPost("feedback")]

        public IActionResult FeedbackDetails(FeedbackModel FeedbackModel)
        {
            if (HttpContext.Session != null)
            {
                int? userid = HttpContext.Session.GetInt32("userid") != null ? HttpContext.Session.GetInt32("userid") : null;
                if (userid != null)
                {
                    //FeedbackModel.User_id = userid != null ? (int)userid : 0;
                    int cnt = _eventRepository.InsertIntoFeedback(FeedbackModel);
                    if (cnt > 0)
                    {
                        return Ok("data updated successfully");
                    }
                }
            }
            return Ok("session is null");

        }
        [HttpPost("eventlink")]

        public IActionResult InsertLinks(EventLinksModel EventLinksModel)
        {
            _eventRepository.InsertIntoEventLink(EventLinksModel);

            return Ok();

        }
        [HttpPost("eventimg")]

        public IActionResult BookedImages([FromForm]  EventImagesModel EventImagesModel )
        {
            try
            {
                //if (EventImagesModel == null || EventImagesModel.Event_img == null || EventImagesModel.Event_id <= 0)
                //{
                //    return BadRequest("Invalid event image data.");
                //}

                _eventRepository.InsertIntoEventImages(EventImagesModel.UploadFile, EventImagesModel);

                return Ok("Event image inserted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpPost("eventcontact")]

        public IActionResult EventContacts(EventContactModel EventContactModel)
        {
            _eventRepository.InsertIntoEventContact(EventContactModel);

            return Ok();

        }
        [HttpPost("usercontact")]  

        public IActionResult UserContacts(UserContactModel UserContactModel)

        {
            if (HttpContext.Session != null)
            {
                int? userid = HttpContext.Session.GetInt32("userid") != null ? HttpContext.Session.GetInt32("userid") : null;
                if (userid != null)
                {
                    UserContactModel.User_id = userid != null ? (int)userid : 0;
                   _eventRepository.InsertIntoUserContact(UserContactModel);
                    
                }
            }
            return Ok("session is null");
        }
        [HttpPost("getfile")]
        public IActionResult Index(IFormFile file)
        {
            if (file != null)
            {
                _eventRepository.UploadFile(file);
            }

            return Ok();
        }
        [HttpPost("validate")]

        public IActionResult LogValidation(UserModel UserModel)
        {
            try
            {
                int id = _eventRepository.ValidateTheUser(UserModel);
                //HttpContext.Session.SetString("userid", id.ToString());


                byte[] data = new byte[1];
                // byte[] data = BitConverter.GetBytes(id);
                data[0] = Convert.ToByte(id);

                HttpContext.Session.Set("userid", data);
                var userid = HttpContext.Session.Get("userid");
                 
                //int id = _eventRepository.ValidateTheUser(UserModel);
                //HttpContext.Session.Add("sessionObjects", new SessionObjects());
                //HttpContext.Session.SetInt32("userid", (int)id);

                return Ok(id);
            }
            catch(SqlException ex)
            {
                string errorMessage = ex.Message;

                // Return a custom error response to the frontend
                return BadRequest(new { Error = errorMessage });
            }
        }
        [HttpGet("yoga_city")]

        public List<YogaEventsCity> GetYogaEventsCity([FromQuery] YogaEventsCity YogaEventsCity)
        {
            List<YogaEventsCity> yogaacity = _eventRepository.GetYogaEventsByCity(YogaEventsCity);
            if (yogaacity.Count == 0)
            {
                NotFound();
            }

            return yogaacity;

        }
        [HttpGet("don_city")]

        public List<DonEventsCity> GetDonEventsCity([FromQuery] DonEventsCity DonEventsCity)
        {
            List<DonEventsCity> doncity = _eventRepository.GetDonEventsByCity(DonEventsCity);
            if (doncity.Count == 0)
            {
                NotFound();
            }

            return doncity;

        }

        [HttpGet("yogaevent")]

        public List<YogaEventsModel> GetEventsOfYoga([FromQuery] YogaEventsModel YogaEventsModel)
        {
            List<YogaEventsModel> yogaaevents = _eventRepository.GetYogaEvents(YogaEventsModel);
            if (yogaaevents.Count == 0)
            {
                NotFound();
            }

            return yogaaevents;

        }
        [HttpGet("donationevent")]

        public List<DonationEventsModel> GetEventsOfDonation([FromQuery] DonationEventsModel DonationEventsModel)
        {
            List<DonationEventsModel> donEvents = _eventRepository.GetDonationEvents(DonationEventsModel);
            if (donEvents.Count == 0)
            {
                NotFound();
            }

            return donEvents;

        }
        [HttpGet("registeredevent")]

        public List<RegisteredEventsModel> RegisteredEvents([FromQuery] int id)
        {

            if (HttpContext.Session != null)
            {
                int? userid = HttpContext.Session.Get("userid")?.Length > 0
              ? Convert.ToInt32(HttpContext.Session.Get("userid")[0])
              : (int?)null;
                //int? userid = HttpContext.Session.GetInt32("userid") != null ? HttpContext.Session.GetInt32("userid") : null;
                if (id != null)
                {
                    List<RegisteredEventsModel> regEvents = _eventRepository.GetRegisteredEvents(id);
                    if (regEvents.Count == 0)
                    {
                        NotFound();
                    }
                    return regEvents;
                }
               
                // var sess = HttpContext.Session.Get("userid");

            }
            return null;

        }
        [HttpGet("openevent")]
        public List<OpenEventModel> OpenEvents([FromQuery] int id)
        {

            if (HttpContext.Session != null)
            {
                int? userid = HttpContext.Session.Get("userid")?.Length > 0
              ? Convert.ToInt32(HttpContext.Session.Get("userid")[0])
              : (int?)null;
                //int? userid = HttpContext.Session.GetInt32("userid") != null ? HttpContext.Session.GetInt32("userid") : null;
                if (id != null)
                {
                    List<OpenEventModel> Events = _eventRepository.GetEvents(id);
                    if (Events.Count == 0)
                    {
                        NotFound();
                    }
                    return Events;
                }

                // var sess = HttpContext.Session.Get("userid");

            }
            return null;

        }
        [HttpGet("feedbackevent")]

        public List<GetFeedbackModel> FeedbackEvents([FromQuery] int id)
        {

            if (HttpContext.Session != null)
            {
                int? userid = HttpContext.Session.Get("userid")?.Length > 0
              ? Convert.ToInt32(HttpContext.Session.Get("userid")[0])
              : (int?)null;
                //int? userid = HttpContext.Session.GetInt32("userid") != null ? HttpContext.Session.GetInt32("userid") : null;
                if (id != null)
                {
                    //GetFeedbackModel.User_id = userid != null ? (int)userid : 0;
                    List<GetFeedbackModel> feedback = _eventRepository.GetEventsForFeedback(id);
                    if (feedback.Count == 0)
                    {
                        NotFound();
                    }
                    return feedback;
                }

                // var sess = HttpContext.Session.Get("userid");
            }
            return null;

        }
        [HttpGet("Ticket")]

        public List<TicketOfConfirmation> GetToc([FromQuery] int user_id,int event_id)
        {

            if (HttpContext.Session != null)
            {
                int? userid = HttpContext.Session.Get("userid")?.Length > 0
             ? Convert.ToInt32(HttpContext.Session.Get("userid")[0])
             : (int?)null;
                // int? userid = Convert.ToInt32(HttpContext.Session.Get("userid")[0]);
                //int? userid = HttpContext.Session.GetInt32("userid") != null ? HttpContext.Session.GetInt32("userid") : null;
                if (user_id != null && event_id != null)
                {
                   // user_id = userid != null ? (int)userid : 0;
                   // event_id = userid != null ? (int)userid : 0;
                    List<TicketOfConfirmation> feedback = _eventRepository.GetTicketOfConfirmation(user_id,  event_id);
                    if (feedback.Count == 0)
                    {
                        NotFound();
                    }
                    return feedback;
                }

                // var sess = HttpContext.Session.Get("userid");
            }
            return null;

        }
    }
}
