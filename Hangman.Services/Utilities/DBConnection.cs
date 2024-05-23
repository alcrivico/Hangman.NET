using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace Hangman.Services.Utilities
{

    public class DBConnection
    {
        public static string connectionString = "Si";
        //public static string connectionstring = "Data Source=PC\\SQLEXPRESS;Initial Catalog=Hangman.Data;Integrated Security=True;Encrypt=False";

        public static DataContext GetConnection()
        {
            return new DataContext(connectionString);
        }

    }

}