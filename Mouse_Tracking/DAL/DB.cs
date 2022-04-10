using Microsoft.Extensions.Configuration;
using Mouse_Tracking.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Mouse_Tracking.DAL
{
  public  class DB
    {
        private string _connectionString;
        public DB(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("Default");
        }

        public void WriteToDb(MouseTracking mouseTracking)
        {
            SqlConnection conn;
            SqlCommand comm;
            //SqlDataReader dreader;

            conn = new SqlConnection(_connectionString);
            conn.Open();
            comm = new SqlCommand("Insert into Mouselog Values('" + mouseTracking.UserId + "','" + DateTime.UtcNow.ToLongDateString() + "','" + mouseTracking.InTime + "','" + mouseTracking.ProductiveTime + "','" + mouseTracking.IdleTime + "','" + mouseTracking.PrivateTime + "','" + mouseTracking.WorkTime + "','" + mouseTracking.Status + "','" + DateTime.UtcNow + "','" + DateTime.UtcNow + "','" + mouseTracking.LeftTime + "')", conn);
            try
            {
                var result=comm.ExecuteNonQuery();
                
            }
            catch (Exception ex )
            {
                
            }
            finally
            {
                conn.Close();
            }



           
        }
    }
}
