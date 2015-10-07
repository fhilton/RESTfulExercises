﻿using System;
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
            var timeLoggingContext = new TimeLoggingContext();

            var result = timeLoggingContext.Logs.Select(l => new TimeLogViewModel()
            {
                UserId = l.UserId,
                StartTime = l.StartTime,
                EndTime = l.EndTime,
                Comment = l.Comment,
                Billable = l.Billable
            });
            return result.ToList();

        }

    }
}