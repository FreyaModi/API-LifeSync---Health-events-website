using lifesync.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace lifesync.Repository
{
    public class OutputRepository: IOutputRepository
    {
        private readonly IWebHostEnvironment _environment;


        public OutputRepository(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////
        public int GetEventsByCity(EventsModel EventsModel)
        {
            string Connect = "Data Source=FREYA-DTS;  User=sa; Password=\"Freya@123\"; TrustServerCertificate=true; Encrypt=true; Connection Timeout =30;database=lifeSync;Server=.";
            using SqlConnection con = new SqlConnection(Connect);
            using SqlCommand cmd = new SqlCommand("GetEventsByCity", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@event_city ", SqlDbType.VarChar).Value = EventsModel.Event_city;
         
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlParameter outputParameter = new SqlParameter("@event_id", SqlDbType.Int);
            outputParameter.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParameter);
            cmd.ExecuteNonQueryAsync();

            int resultId = (int)cmd.Parameters["@event_id"].Value;
            return resultId;
        }
    }
}
