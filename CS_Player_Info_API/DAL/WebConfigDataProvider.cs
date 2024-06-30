using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CS_Player_Info_API.DAL
{
    public class WebConfigDataProvider
    {
        private static string _connectionString;
        WebConfigDataProvider()
        {
            _connectionString = null;
        }
        public static string GetConnString()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["PlayerInformation"].ConnectionString; // Server=DESKTOP-6MGNN18;Database=PlayerInfo;Integrated Security=True;TrustServerCertificate=True;
            return _connectionString;
        }

    }
}