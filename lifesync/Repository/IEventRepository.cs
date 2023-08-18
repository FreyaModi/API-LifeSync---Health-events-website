using lifesync.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient.Server;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace lifesync.Repository
{
    public interface IEventRepository

    {
         List<DonEventsCity> GetDonEventsByCity(DonEventsCity DonEventsCity);
         List<YogaEventsCity> GetYogaEventsByCity(YogaEventsCity YogaEventsCity);
        List<TicketOfConfirmation> GetTicketOfConfirmation(int user_id, int event_id);
        List<GetFeedbackModel> GetEventsForFeedback(int id);
        List<RegisteredEventsModel> GetRegisteredEvents(int id);
        List<DonationEventsModel> GetDonationEvents(DonationEventsModel DonationEventsModel);
        List<YogaEventsModel> GetYogaEvents(YogaEventsModel YogaEventsModel);
  
        int UpdateTheLogs(Registration Registration);
      int ValidateTheUser(UserModel UserModel);
      void UploadFile(IFormFile file);
      void InsertIntoUsers(UserModel UserModel);
     int InsertIntoEvents( EventsModel EventsModel);
     int InsertIntoBookedEvents(BookedEventsModel BokedEventsModel);
        void CoverImage(CoverImageModel formData);
     int InsertIntoFeedback(FeedbackModel FeedbackModel);
     void InsertIntoEventContact(EventContactModel EventContactModel);
     void InsertIntoEventImages(IFormFile file, EventImagesModel EventImagesModel);
     void InsertIntoEventLink(EventLinksModel EventLinksModel);
     int InsertIntoUserContact(UserContactModel UserContactModel);
     int UpdateIntoUsers(UserModel UserModel);
        List<OpenEventModel> GetEvents(int id);


    }
}
