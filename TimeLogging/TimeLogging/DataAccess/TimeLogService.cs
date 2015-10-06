using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeLogging.Models;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace TimeLogging.DataAccess
{
    public class TimeLogService
    {
        public static List<TimeLogViewModel> GetFiveLatestEntries()
        {
            var result = new List<TimeLogViewModel>();

            var connStr = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select top(5) * from dbo.TimeLogs";
                var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var entry = new TimeLogViewModel();
                    entry.UserId = rdr.GetString(1);
                    entry.StartTime = rdr.GetDateTime(2);
                    entry.EndTime = rdr.GetDateTime(3);
                    entry.Comment = rdr.GetString(4);
                    entry.Billable = rdr.GetBoolean(5);

                    result.Add(entry);
                }

                conn.Close();
            }

            return result;
        }
    }
}