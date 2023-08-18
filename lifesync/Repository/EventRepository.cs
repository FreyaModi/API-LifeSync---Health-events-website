using Microsoft.Data.SqlClient;
using System.Data;
using System;
using Microsoft.Extensions.Options;
using lifesync.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace lifesync.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly IWebHostEnvironment _environment;


        public EventRepository(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        ////////////////////////////////////////////////////////////////////////////////////
        public void InsertIntoUsers(UserModel UserModel)
        {
            string Connect = "Data Source=FREYA-DTS;  User=sa; Password=\"Freya@123\"; TrustServerCertificate=true; Encrypt=true; Connection Timeout =30;database=lifeSync;Server=.";
            using SqlConnection con = new SqlConnection(Connect);
            using SqlCommand cmd = new SqlCommand("UserInsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            // Add an output parameter to retrieve the generated primary key
            var idParam = new SqlParameter("@user_id", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            //cmd.Parameters.Add(idParam);


            cmd.Parameters.Add("@user_emailid", SqlDbType.VarChar).Value = UserModel.User_emailid;
            cmd.Parameters.Add("@user_type", SqlDbType.VarChar).Value = UserModel.User_type;
            cmd.Parameters.Add("@user_pic", SqlDbType.VarChar).Value = UserModel.User_pic;
            cmd.Parameters.Add("@user_name", SqlDbType.VarChar).Value = UserModel.User_name;
            cmd.Parameters.Add("@org_name", SqlDbType.VarChar).Value = UserModel.Org_name;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = UserModel.Password;
            cmd.Parameters.Add("@user_dob", SqlDbType.Date).Value = UserModel.User_dob;
            cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = UserModel.Gender;
            cmd.Parameters.Add("@user_address", SqlDbType.VarChar).Value = UserModel.User_address;
            cmd.Parameters.Add("@blood_group", SqlDbType.VarChar).Value = UserModel.Blood_group;
            cmd.Parameters.Add("@user_city", SqlDbType.VarChar).Value = UserModel.User_city;
            cmd.Parameters.Add("@user_description", SqlDbType.VarChar).Value = UserModel.User_description;
            cmd.Parameters.Add("@person_contact", SqlDbType.VarChar).Value = UserModel.Person_contact;
            cmd.Parameters.Add("@eve_select_id", SqlDbType.Int).Value = UserModel.Eve_select;

            //int userId = Convert.ToInt32(idParam.Value);

            // Associate the userId with the user's session, token, or other mechanism for future updates
            con.Open();
            var a = cmd.ExecuteNonQuery();
            var b = 6;
        }

        ////////////////////////////////////////////////////////////////////////////////////
        public int UpdateIntoUsers(UserModel UserModel)
        {
            string Connect = "Data Source=FREYA-DTS;  User=sa; Password=\"Freya@123\"; TrustServerCertificate=true; Encrypt=true; Connection Timeout =30;database=lifeSync;Server=.";
            using SqlConnection con = new SqlConnection(Connect);
            using SqlCommand cmd = new SqlCommand("UserUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            // Add an output parameter to retrieve the generated primary key


            cmd.Parameters.Add("@user_id", SqlDbType.VarChar).Value = UserModel.User_id;
            cmd.Parameters.Add("@user_type", SqlDbType.VarChar).Value = UserModel.User_type;
            cmd.Parameters.Add("@user_pic", SqlDbType.VarChar).Value = UserModel.User_pic;
            cmd.Parameters.Add("@user_name", SqlDbType.VarChar).Value = UserModel.User_name;
            cmd.Parameters.Add("@org_name", SqlDbType.VarChar).Value = UserModel.Org_name;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = UserModel.Password;
            cmd.Parameters.Add("@user_dob", SqlDbType.Date).Value = UserModel.User_dob;
            cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = UserModel.Gender;
            cmd.Parameters.Add("@user_address", SqlDbType.VarChar).Value = UserModel.User_address;
            cmd.Parameters.Add("@blood_group", SqlDbType.VarChar).Value = UserModel.Blood_group;
            cmd.Parameters.Add("@user_city", SqlDbType.VarChar).Value = UserModel.User_city;
            cmd.Parameters.Add("@user_description", SqlDbType.VarChar).Value = UserModel.User_description;
            cmd.Parameters.Add("@person_contact", SqlDbType.VarChar).Value = UserModel.Person_contact;
            cmd.Parameters.Add("@eve_select_id", SqlDbType.Int).Value = UserModel.Eve_select;


            // Associate the userId with the user's session, token, or other mechanism for future updates
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();
            return count;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public int InsertIntoEvents( EventsModel EventsModel)
        {
            //var filePath = "";
            //var fileName = Path.GetFileName(file.FileName);
            //var myUniqueFileName = Convert.ToString(Guid.NewGuid());
            //var fileExtension = Path.GetExtension(fileName);
            //var newFileName = string.Concat(myUniqueFileName, fileExtension);
            //filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", newFileName);
            ////filePath = Path.GetFullPath(newFileName);

            //using (var stream = new FileStream(filePath, FileMode.Create))
            //{
            //    file.CopyTo(stream);
            //    stream.Flush();
            //}
            string Connect = "Data Source=FREYA-DTS;  User=sa; Password=\"Freya@123\"; TrustServerCertificate=true; Encrypt=true; Connection Timeout =30;database=lifeSync;Server=.";
            using SqlConnection con = new SqlConnection(Connect);
            using SqlCommand cmd = new SqlCommand("EventInsert", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@event_name", SqlDbType.VarChar).Value = EventsModel.Event_name;
            cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = EventsModel.User_id;
            cmd.Parameters.Add("@event_org", SqlDbType.VarChar).Value = EventsModel.Event_org;
            cmd.Parameters.Add("@date_from", SqlDbType.Date).Value = EventsModel.Date_from;
            cmd.Parameters.Add("@date_to", SqlDbType.Date).Value = EventsModel.Date_to;
            cmd.Parameters.Add("duration_from", SqlDbType.Time).Value = EventsModel.Duration_from;
            cmd.Parameters.Add("@duration_to", SqlDbType.Time).Value = EventsModel.Duration_to;
            cmd.Parameters.Add("@event_city", SqlDbType.VarChar).Value = EventsModel.Event_city;
            cmd.Parameters.Add("@event_address", SqlDbType.VarChar).Value = EventsModel.Event_address;
            cmd.Parameters.Add("@event_deadline", SqlDbType.DateTime).Value = EventsModel.Event_deadline;
            cmd.Parameters.Add("@event_desc", SqlDbType.VarChar).Value = EventsModel.Event_desc;
            cmd.Parameters.Add("@event_area", SqlDbType.VarChar).Value = EventsModel.Event_area;
            cmd.Parameters.Add("@event_seats", SqlDbType.Int).Value = EventsModel.Event_seats;
          //  cmd.Parameters.Add("@event_seats", SqlDbType.Int).Value = newFileName;
            cmd.Parameters.Add("@event_type", SqlDbType.VarChar).Value = EventsModel.Event_type;
            cmd.Parameters.Add("@sub_type", SqlDbType.VarChar).Value = EventsModel.Sub_type;
            cmd.Parameters.Add("@event_status", SqlDbType.Int).Value = EventsModel.Event_status;

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            int id = 0;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // Iterate through the reader to access the ID values
                while (reader.Read())
                {
                    // Access the ID column value
                    id = Convert.ToInt16(reader[0]);

                    // Do something with the ID value
                    Console.WriteLine("ID: " + id);
                }
            }
            return id;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        public int InsertIntoBookedEvents(BookedEventsModel BookedEventsModel)
        {
            string Connect = "Data Source=FREYA-DTS;  User=sa; Password=\"Freya@123\"; TrustServerCertificate=true; Encrypt=true; Connection Timeout =30;database=lifeSync;Server=.";
            using SqlConnection con = new SqlConnection(Connect);
            using SqlCommand cmd = new SqlCommand("BookedEventDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = BookedEventsModel.User_id;
            cmd.Parameters.Add("@event_id", SqlDbType.Int).Value = BookedEventsModel.Event_id;


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();
            return count;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////
        public int ValidateTheUser(UserModel UserModel)
        {
            string Connect = "Data Source=FREYA-DTS;  User=sa; Password=\"Freya@123\"; TrustServerCertificate=true; Encrypt=true; Connection Timeout =30;database=lifeSync;Server=.";
            using SqlConnection con = new SqlConnection(Connect);
            using SqlCommand cmd = new SqlCommand("ValidateUser", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@user_emailid", SqlDbType.VarChar).Value = UserModel.User_emailid;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = UserModel.Password;


            con.Open();
            int id = 0;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // Iterate through the reader to access the ID values
                while (reader.Read())
                {
                    // Access the ID column value
                    id = Convert.ToInt16(reader[0]);

                    // Do something with the ID value
                    Console.WriteLine("ID: " + id);
                }
            }
            return id;

        }
        ////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////////
        public int UpdateTheLogs(Registration Registration)
        {
            string Connect = "Data Source=FREYA-DTS;  User=sa; Password=\"Freya@123\"; TrustServerCertificate=true; Encrypt=true; Connection Timeout =30;database=lifeSync;Server=.";
            using SqlConnection con = new SqlConnection(Connect);
            using SqlCommand cmd = new SqlCommand("UpdateLogs", con);
            cmd.CommandType = CommandType.StoredProcedure;



            cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = Registration.User_id;


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();
            return count;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        public int InsertIntoFeedback(FeedbackModel FeedbackModel)
        {
            string Connect = "Data Source=FREYA-DTS;  User=sa; Password=\"Freya@123\"; TrustServerCertificate=true; Encrypt=true; Connection Timeout =30;database=lifeSync;Server=.";
            using SqlConnection con = new SqlConnection(Connect);
            using SqlCommand cmd = new SqlCommand("FeedbackDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@rating", SqlDbType.Int).Value = FeedbackModel.Rating;
            cmd.Parameters.Add("@feedback_desc ", SqlDbType.VarChar).Value = FeedbackModel.Feedback_desc;
            cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = FeedbackModel.User_id;
            cmd.Parameters.Add("@event_id", SqlDbType.Int).Value = FeedbackModel.Event_id;


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();
            return count;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////
        public int InsertIntoUserContact(UserContactModel UserContactModel)
        {
            string Connect = "Data Source=FREYA-DTS;  User=sa; Password=\"Freya@123\"; TrustServerCertificate=true; Encrypt=true; Connection Timeout =30;database=lifeSync;Server=.";
            using SqlConnection con = new SqlConnection(Connect);
            using SqlCommand cmd = new SqlCommand("UserContactDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = UserContactModel.User_id;
            cmd.Parameters.Add("@user_contactno ", SqlDbType.VarChar).Value = UserContactModel.User_contactno;


            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();
            return count;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////
        public void InsertIntoEventLink(EventLinksModel EventLinksModel)
        {
            string Connect = "Data Source=FREYA-DTS;  User=sa; Password=\"Freya@123\"; TrustServerCertificate=true; Encrypt=true; Connection Timeout =30;database=lifeSync;Server=.";
            using SqlConnection con = new SqlConnection(Connect);
            using SqlCommand cmd = new SqlCommand("EventLinkDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@event_id ", SqlDbType.Int).Value = EventLinksModel.Event_id;
            cmd.Parameters.Add("@event_links ", SqlDbType.NVarChar).Value = EventLinksModel.Event_links;


            con.Open();
            cmd.ExecuteNonQuery();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////
        // public void InsertIntoEventImages(EventImagesModel EventImagesModel)
        //{
        //    string Connect = "Data Source=FREYA-DTS;  User=sa; Password=\"Freya@123\"; TrustServerCertificate=true; Encrypt=true; Connection Timeout =30;database=lifeSync;Server=.";
        //    using SqlConnection con = new SqlConnection(Connect);
        //    using SqlCommand cmd = new SqlCommand("EventLinkDetails", con);
        //    cmd.CommandType = CommandType.StoredProcedure;


        //    cmd.Parameters.Add("@event_id ", SqlDbType.Int).Value = EventImagesModel.Event_id;
        //    cmd.Parameters.Add("@event_img ", SqlDbType.VarChar).Value = EventImagesModel.Event_img;


        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //}
        public void InsertIntoEventImages(IFormFile file,EventImagesModel EventImagesModel)
        {
            /*  try
               {*/
            // System.Console.WriteLine("Hello World!", EventImagesModel.Event_id,file);
            var filePath = "";
     
            var fileName = Path.GetFileName(file.FileName);
            var myUniqueFileName = Convert.ToString(Guid.NewGuid());
            var fileExtension = Path.GetExtension(fileName);
            var newFileName = string.Concat(myUniqueFileName, fileExtension);
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", newFileName);
            //filePath = Path.GetFullPath(newFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
                    stream.Flush();
                }

            string Connect = "Data Source=FREYA-DTS;  User=sa; Password=\"Freya@123\"; TrustServerCertificate=true; Encrypt=true; Connection Timeout =30;database=lifeSync;Server=.";
            using SqlConnection con = new SqlConnection(Connect);
            using SqlCommand cmd = new SqlCommand("EventImagesDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@event_id ", SqlDbType.Int).Value = EventImagesModel.Event_id;
            cmd.Parameters.Add("@event_img ", SqlDbType.VarChar).Value = newFileName;


            con.Open();
            cmd.ExecuteNonQuery();


               }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void CoverImage(CoverImageModel formData)
        {
            /*  try
               {*/
            // System.Console.WriteLine("Hello World!", EventImagesModel.Event_id,file);
            var filePath = "";

            var fileName = Path.GetFileName(formData.file.FileName);
            var myUniqueFileName = Convert.ToString(Guid.NewGuid());
            var fileExtension = Path.GetExtension(fileName);
            var newFileName = string.Concat(myUniqueFileName, fileExtension);
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", newFileName);
            //filePath = Path.GetFullPath(newFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                formData.file.CopyTo(stream);
                stream.Flush();
            }

            string Connect = "Data Source=FREYA-DTS;  User=sa; Password=\"Freya@123\"; TrustServerCertificate=true; Encrypt=true; Connection Timeout =30;database=lifeSync;Server=.";
            using SqlConnection con = new SqlConnection(Connect);
            using SqlCommand cmd = new SqlCommand("AddCover", con);
            cmd.CommandType = CommandType.StoredProcedure;


           cmd.Parameters.Add("@event_id ", SqlDbType.Int).Value = formData.Event_id;
            cmd.Parameters.Add("@cover_pic ", SqlDbType.VarChar).Value = newFileName;


            con.Open();
            cmd.ExecuteNonQuery();


        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        public void InsertIntoEventContact(EventContactModel EventContactModel)
        {
            string Connect = "Data Source=FREYA-DTS;  User=sa; Password=\"Freya@123\"; TrustServerCertificate=true; Encrypt=true; Connection Timeout =30;database=lifeSync;Server=.";
            using SqlConnection con = new SqlConnection(Connect);
            using SqlCommand cmd = new SqlCommand("EventContactDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@event_id ", SqlDbType.Int).Value = EventContactModel.Event_id;
            cmd.Parameters.Add("@event_contactno ", SqlDbType.VarChar).Value = EventContactModel.Event_contactno;


            con.Open();
            cmd.ExecuteNonQuery();
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        public void UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                var fileExtension = Path.GetExtension(fileName);
                var newFileName = string.Concat(myUniqueFileName, fileExtension);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", newFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                }
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////
        public List<YogaEventsCity> GetYogaEventsByCity(YogaEventsCity YogaEventsCity)
        {
            string Connect = "Data Source=FREYA-DTS;  User=sa; Password=\"Freya@123\"; TrustServerCertificate=true; Encrypt=true; Connection Timeout =30;database=lifeSync;Server=.";
            using SqlConnection con = new SqlConnection(Connect);
            using SqlCommand cmd = new SqlCommand("GetEventsByYogaCity", con);
            DataSet dataset = new DataSet();
            DataTable datatable = new DataTable();
            List<int> events = new List<int>();
            cmd.CommandType = CommandType.StoredProcedure;


              cmd.Parameters.Add("@event_city ", SqlDbType.VarChar).Value = YogaEventsCity.Event_city;


            con.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                // Fill the DataSet using default values for DataTable names, etc
                da.Fill(dataset);
                datatable = dataset.Tables[0];

            }
            con.Close();
            List<YogaEventsCity> yogaaCity = new List<YogaEventsCity>();
            foreach (DataRow row in datatable.Rows)
            {

                YogaEventsCity yogaCity = new YogaEventsCity();
                yogaCity.Event_name = row["event_name"].ToString();
                yogaCity.Event_city = row["event_city"].ToString();
                yogaCity.Event_area = row["event_area"].ToString();
                yogaCity.Cover_pic = row["cover_pic"].ToString();
                yogaCity.Date_from = Convert.ToDateTime(row["date_from"]);
                yogaCity.Date_to = Convert.ToDateTime(row["date_to"]);
                yogaCity.Duration_from = TimeSpan.Parse(row["duration_from"].ToString());
                yogaCity.Duration_to = TimeSpan.Parse(row["duration_to"].ToString());
                yogaCity.Event_deadline = Convert.ToDateTime(row["event_deadline"]);
                yogaaCity.Add(yogaCity);
            }


            return yogaaCity;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////
        public List<DonEventsCity> GetDonEventsByCity(DonEventsCity DonEventsCity)
        {
            string Connect = "Data Source=FREYA-DTS;  User=sa; Password=\"Freya@123\"; TrustServerCertificate=true; Encrypt=true; Connection Timeout =30;database=lifeSync;Server=.";
            using SqlConnection con = new SqlConnection(Connect);
            using SqlCommand cmd = new SqlCommand("GetEventsByDonCity", con);
            DataSet dataset = new DataSet();
            DataTable datatable = new DataTable();
            List<int> events = new List<int>();
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@event_city ", SqlDbType.VarChar).Value = DonEventsCity.Event_city;


            con.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                // Fill the DataSet using default values for DataTable names, etc
                da.Fill(dataset);
                datatable = dataset.Tables[0];

            }
            con.Close();
            List<DonEventsCity>donCity = new List<DonEventsCity>();
            foreach (DataRow row in datatable.Rows)
            {

                DonEventsCity donationCity = new DonEventsCity();
                donationCity.Event_name = row["event_name"].ToString();
                donationCity.Event_city = row["event_city"].ToString();
                donationCity.Event_area = row["event_area"].ToString();
                donationCity.Cover_pic = row["cover_pic"].ToString();

                donationCity.Date_from = Convert.ToDateTime(row["date_from"]);
                donationCity.Date_to = Convert.ToDateTime(row["date_to"]);
                donationCity.Duration_from = TimeSpan.Parse(row["duration_from"].ToString());
                donationCity.Duration_to = TimeSpan.Parse(row["duration_to"].ToString());
                donationCity.Event_deadline = Convert.ToDateTime(row["event_deadline"]);
                donCity.Add(donationCity);
            }


            return donCity;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////
        public List<YogaEventsModel> GetYogaEvents(YogaEventsModel YogaEventsModel)
        {
            string Connect = "Data Source=FREYA-DTS;  User=sa; Password=\"Freya@123\"; TrustServerCertificate=true; Encrypt=true; Connection Timeout =30;database=lifeSync;Server=.";
            using SqlConnection con = new SqlConnection(Connect);
            using SqlCommand cmd = new SqlCommand("GetYogaEvents", con);
            DataSet dataset = new DataSet();
            DataTable datatable = new DataTable();
            List<int> events = new List<int>();
            cmd.CommandType = CommandType.StoredProcedure;

            //  cmd.Parameters.Add("@event_city ", SqlDbType.VarChar).Value = EventsModel.Event_city;
            con.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                // Fill the DataSet using default values for DataTable names, etc
                da.Fill(dataset);
                datatable = dataset.Tables[0];

            }
            con.Close();
            List<YogaEventsModel> yogaaEvents = new List<YogaEventsModel>();
            foreach (DataRow row in datatable.Rows)
            {

                byte[] imageBytes = null;
                YogaEventsModel yogaEvent = new YogaEventsModel();
                yogaEvent.Event_name = row["event_name"].ToString();
                yogaEvent.Event_city = row["event_city"].ToString();
                yogaEvent.Event_area = row["event_area"].ToString();
                yogaEvent.Event_org = row["event_org"].ToString();
                yogaEvent.Event_type = row["event_type"].ToString();
                yogaEvent.Event_id = Convert.ToInt32(row["event_id"]);
                yogaEvent.Sub_type = row["sub_type"].ToString();
                // byte[] byt = System.Text.Encoding.UTF8.GetBytes(row["cover_pic"].ToString());
                string img = row["cover_pic"].ToString();
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", img);
                // var imageFileStream = System.IO.File.OpenRead(filePath);
                // yogaEvent.Cover_pic = Convert.ToBase64String(@"filepath");
                using (var imageFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        imageFileStream.CopyTo(memoryStream);
                        imageBytes = memoryStream.ToArray();

                        // Now 'imageBytes' contains the binary image data
                        // You can proceed to convert it to a Base64 string or use it as needed
                    }
                }
                yogaEvent.Cover_pic = Convert.ToBase64String (imageBytes);
                byte[] decodedImageBytes = Convert.FromBase64String(yogaEvent.Cover_pic);
                yogaEvent.Date_from = Convert.ToDateTime(row["date_from"].ToString());
                yogaEvent.Date_to = Convert.ToDateTime(row["date_to"]);
                yogaEvent.Duration_from = TimeSpan.Parse(row["duration_from"].ToString());
                yogaEvent.Duration_to = TimeSpan.Parse(row["duration_to"].ToString());
                yogaEvent.Event_deadline = Convert.ToDateTime(row["event_deadline"]);
                yogaaEvents.Add(yogaEvent);
            }
            return yogaaEvents;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////
        public List<OpenEventModel> GetEvents(int id)
        {
            string Connect = "Data Source=FREYA-DTS;  User=sa; Password=\"Freya@123\"; TrustServerCertificate=true; Encrypt=true; Connection Timeout =30;database=lifeSync;Server=.";
            using SqlConnection con = new SqlConnection(Connect);
            using SqlCommand cmd = new SqlCommand("GetEventDetails", con);
            DataSet dataset = new DataSet();
            DataTable datatable = new DataTable();
            List<int> events = new List<int>();
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@event_id", SqlDbType.Int).Value = id;
            //  cmd.Parameters.Add("@event_city ", SqlDbType.VarChar).Value = EventsModel.Event_city;
            con.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                // Fill the DataSet using default values for DataTable names, etc
                da.Fill(dataset);
                datatable = dataset.Tables[0];

            }
            con.Close();
            List<OpenEventModel> Events = new List<OpenEventModel>();
            foreach (DataRow row in datatable.Rows)
            {

               
                OpenEventModel eveData = new OpenEventModel();
                eveData.Event_name = row["event_name"].ToString();
                eveData.Event_city = row["event_city"].ToString();
                eveData.Event_area = row["event_area"].ToString();
                eveData.Event_org = row["event_org"].ToString();

                eveData.Date_from = Convert.ToDateTime(row["date_from"].ToString());
                eveData.Date_to = Convert.ToDateTime(row["date_to"]);
                eveData.Duration_from = TimeSpan.Parse(row["duration_from"].ToString());
                eveData.Duration_to = TimeSpan.Parse(row["duration_to"].ToString());
                //  eveData.Event_deadline = Convert.ToDateTime(row["event_deadline"]);
                Events.Add(eveData);
            }
            return Events;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////
        public List<DonationEventsModel> GetDonationEvents(DonationEventsModel DonationEventsModel)
        {
            string Connect = "Data Source=FREYA-DTS;  User=sa; Password=\"Freya@123\"; TrustServerCertificate=true; Encrypt=true; Connection Timeout =30;database=lifeSync;Server=.";
            using SqlConnection con = new SqlConnection(Connect);
            using SqlCommand cmd = new SqlCommand("GetDonationEvents", con);
            DataSet dataset = new DataSet();
            DataTable datatable = new DataTable();
            List<int> events = new List<int>();
            cmd.CommandType = CommandType.StoredProcedure;


            //  cmd.Parameters.Add("@event_city ", SqlDbType.VarChar).Value = EventsModel.Event_city;


            con.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                // Fill the DataSet using default values for DataTable names, etc
                da.Fill(dataset);
                datatable = dataset.Tables[0];

            }
            con.Close();
            List<DonationEventsModel> donEvents = new List<DonationEventsModel>();
            foreach (DataRow row in datatable.Rows)
            {
                byte[] imageBytes = null;
                DonationEventsModel donationEvent = new DonationEventsModel();
                donationEvent.Event_name = row["event_name"].ToString();
                donationEvent.Event_city = row["event_city"].ToString();
                donationEvent.Event_type = row["event_type"].ToString();
                donationEvent.Sub_type = row["sub_type"].ToString();
                donationEvent.Event_org = row["event_org"].ToString();
                
                donationEvent.Event_id = Convert.ToInt32(row["event_id"]);
                donationEvent.Event_area = row["event_area"].ToString();
                string img = row["cover_pic"].ToString();
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", img);
                // var imageFileStream = System.IO.File.OpenRead(filePath);
                // yogaEvent.Cover_pic = Convert.ToBase64String(@"filepath");
                using (var imageFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        imageFileStream.CopyTo(memoryStream);
                        imageBytes = memoryStream.ToArray();

                        // Now 'imageBytes' contains the binary image data
                        // You can proceed to convert it to a Base64 string or use it as needed
                    }
                }
                donationEvent.Cover_pic = Convert.ToBase64String(imageBytes);
                byte[] decodedImageBytes = Convert.FromBase64String(donationEvent.Cover_pic);
                donationEvent.Date_from = Convert.ToDateTime(row["date_from"]);
                donationEvent.Date_to = Convert.ToDateTime(row["date_to"]);
                donationEvent.Duration_from = TimeSpan.Parse(row["duration_from"].ToString());
                donationEvent.Duration_to = TimeSpan.Parse(row["duration_to"].ToString());
                donationEvent.Event_deadline = Convert.ToDateTime(row["event_deadline"]);
                donEvents.Add(donationEvent);
            }

             
            return donEvents;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////
        public List<RegisteredEventsModel> GetRegisteredEvents(int id)
        {
            string Connect = "Data Source=FREYA-DTS;  User=sa; Password=\"Freya@123\"; TrustServerCertificate=true; Encrypt=true; Connection Timeout =30;database=lifeSync;Server=.";
            using SqlConnection con = new SqlConnection(Connect);
            using SqlCommand cmd = new SqlCommand("GetRegisteredEvents", con);
            DataSet dataset = new DataSet();
            DataTable datatable = new DataTable();
            List<int> events = new List<int>();
            cmd.CommandType = CommandType.StoredProcedure;


             cmd.Parameters.Add("@user_id", SqlDbType.Int).Value =id;


            con.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                // Fill the DataSet using default values for DataTable names, etc
                da.Fill(dataset);
                datatable = dataset.Tables[0];

            }
            con.Close();
            List<RegisteredEventsModel> regEvents = new List<RegisteredEventsModel>();
            foreach (DataRow row in datatable.Rows)
            {
                byte[] imageBytes = null;

                RegisteredEventsModel registeredEvent = new RegisteredEventsModel();
                registeredEvent.Event_name = row["event_name"].ToString();
                registeredEvent.Event_city = row["event_city"].ToString();
                registeredEvent.Event_area = row["event_area"].ToString();
                string img = row["cover_pic"].ToString();
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", img);
                // var imageFileStream = System.IO.File.OpenRead(filePath);
                // yogaEvent.Cover_pic = Convert.ToBase64String(@"filepath");
                using (var imageFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        imageFileStream.CopyTo(memoryStream);
                        imageBytes = memoryStream.ToArray();

                        // Now 'imageBytes' contains the binary image data
                        // You can proceed to convert it to a Base64 string or use it as needed
                    }
                }
                registeredEvent.Cover_pic = Convert.ToBase64String(imageBytes);
                byte[] decodedImageBytes = Convert.FromBase64String(registeredEvent.Cover_pic);
                registeredEvent.Date_from = Convert.ToDateTime(row["date_from"]);
                registeredEvent.Date_to = Convert.ToDateTime(row["date_to"]);
                registeredEvent.Duration_from = TimeSpan.Parse(row["duration_from"].ToString());
                registeredEvent.Duration_to = TimeSpan.Parse(row["duration_to"].ToString());
                registeredEvent.Event_deadline = Convert.ToDateTime(row["event_deadline"]);
                regEvents.Add(registeredEvent);
            }


            return regEvents;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////
        public List<GetFeedbackModel> GetEventsForFeedback(int id)
        {
            string Connect = "Data Source=FREYA-DTS;  User=sa; Password=\"Freya@123\"; TrustServerCertificate=true; Encrypt=true; Connection Timeout =30;database=lifeSync;Server=.";
            using SqlConnection con = new SqlConnection(Connect);
            using SqlCommand cmd = new SqlCommand("GetEventsForFeedback", con);
            DataSet dataset = new DataSet();
            DataTable datatable = new DataTable();
            List<int> events = new List<int>();
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@user_id", SqlDbType.VarChar).Value = id;


            con.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                // Fill the DataSet using default values for DataTable names, etc
                da.Fill(dataset);
                datatable = dataset.Tables[0];

            }
            con.Close();
            List<GetFeedbackModel> fbEvents = new List<GetFeedbackModel>();
            foreach (DataRow row in datatable.Rows)
            {
                byte[] imageBytes = null;

                GetFeedbackModel feedbackEvent = new GetFeedbackModel();
                feedbackEvent.Event_name = row["event_name"].ToString();
                feedbackEvent.Event_city = row["event_city"].ToString();
                feedbackEvent.Event_area = row["event_area"].ToString();
                string img = row["cover_pic"].ToString();
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", img);
                // var imageFileStream = System.IO.File.OpenRead(filePath);
                // yogaEvent.Cover_pic = Convert.ToBase64String(@"filepath");
                using (var imageFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        imageFileStream.CopyTo(memoryStream);
                        imageBytes = memoryStream.ToArray();

                        // Now 'imageBytes' contains the binary image data
                        // You can proceed to convert it to a Base64 string or use it as needed
                    }
                }
                feedbackEvent.Cover_pic = Convert.ToBase64String(imageBytes);
                byte[] decodedImageBytes = Convert.FromBase64String(feedbackEvent.Cover_pic);
                feedbackEvent.Date_from = Convert.ToDateTime(row["date_from"]);
                feedbackEvent.Date_to = Convert.ToDateTime(row["date_to"]);
                feedbackEvent.Duration_from = TimeSpan.Parse(row["duration_from"].ToString());
                feedbackEvent.Duration_to = TimeSpan.Parse(row["duration_to"].ToString());
                feedbackEvent.Event_deadline = Convert.ToDateTime(row["event_deadline"]);
                fbEvents.Add(feedbackEvent);
            }


            return fbEvents;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////
        public List<TicketOfConfirmation> GetTicketOfConfirmation(int user_id, int event_id)
        {
            string Connect = "Data Source=FREYA-DTS;  User=sa; Password=\"Freya@123\"; TrustServerCertificate=true; Encrypt=true; Connection Timeout =30;database=lifeSync;Server=.";
            using SqlConnection con = new SqlConnection(Connect);
            using SqlCommand cmd = new SqlCommand("GetTicketOfConfirmation", con);
            DataSet dataset = new DataSet();
            DataTable datatable = new DataTable();
            List<int> events = new List<int>();
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@user_id", SqlDbType.VarChar).Value =user_id;
            cmd.Parameters.Add("@event_id", SqlDbType.VarChar).Value = event_id;


            con.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                // Fill the DataSet using default values for DataTable names, etc
                da.Fill(dataset);
                datatable = dataset.Tables[0];

            }
            con.Close();
            List<TicketOfConfirmation> toc = new List<TicketOfConfirmation>();
            foreach (DataRow row in datatable.Rows)
            {

                TicketOfConfirmation getToc = new TicketOfConfirmation();
                getToc.Event_name = row["event_name"].ToString();
                getToc.Event_city = row["event_city"].ToString();
                getToc.Event_area = row["event_area"].ToString();
                getToc.User_name = row["user_name"].ToString();
                getToc.Event_org = row["event_org"].ToString();
                getToc.Age = int.Parse(row["age"].ToString());
                getToc.Date_from = Convert.ToDateTime(row["date_from"]);
                getToc.Date_to = Convert.ToDateTime(row["date_to"]);
                getToc.Duration_from = TimeSpan.Parse(row["duration_from"].ToString());
                getToc.Duration_to = TimeSpan.Parse(row["duration_to"].ToString());
                toc.Add(getToc);
            }


            return toc;
        }
    }

}
