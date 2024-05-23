using Hangman.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace Hangman.Services.Models.DTO
{
    public class GameDTO
    {
        public static Dictionary<string, object> LogIn (string email, string password)
        {
            Dictionary <string, object> response = new Dictionary<string, object> ();
            response.Add("Error", true);
            DataContext data = DBConnection.GetConnection();

            if (data != null)
            {

            }
            else
            {
                response.Add("Mensaje", "Correo y/o contraseña incorrectos. Por favor, verifíquelos");
            }
        }
    }
}