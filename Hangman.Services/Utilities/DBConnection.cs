using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace Hangman.Services.Utilities
{
    public class DBConnection
    {
        public static string connectionString = "Data Source=hangman-uv.database.windows.net;Initial Catalog=Hangman.data;Persist Security Info=True;User ID=hangman;Password=soyunpockemonytuno123#";

        public static DataContext GetConnection()
        {
            return new DataContext(connectionString);
        }
    }
}