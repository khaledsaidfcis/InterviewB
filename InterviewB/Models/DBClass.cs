using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterviewB.Models;

namespace InterviewB.Models
{
    //Singleton DBClass To insure the we had ONe Instance of DB Connection
    public static class DBClass
    {
        private static InterviewContext _db = null; //new InterviewContext();

        public static InterviewContext GetConnection()
        {
            if (_db == null)
                _db = new InterviewContext();
            

            return _db;
        }

        public static void disconnect()
        {
            _db.Dispose();
        }
    }
}