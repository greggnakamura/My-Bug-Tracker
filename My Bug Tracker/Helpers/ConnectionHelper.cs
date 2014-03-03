using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace My_Bug_Tracker.Helpers
{
    public static class ConnectionHelper
    {
        public static readonly string ConnectionStringName = "DefaultConnection";

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
        }
    }
}
