using Hangman.Services.Models.POCO;
using Hangman.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hangman.Services.Models.DTO
{
    public class PlayerDTO
    {
        public static Dictionary<string, object> LogIn(string email, string password)
        {
            Dictionary<string, object> response = new Dictionary<string, object>();
            response.Add("Error", true);
            DataContext data = DBConnection.GetConnection();

            if (data != null)
            {
                try
                {
                    Table<Player> playerTable = data.GetTable<Player>();

                    var query = from player in playerTable
                                where player.Email == email && player.Password == password
                                select player;

                    if (query.Any())
                    {
                        response["Error"] = false;
                        response.Add("Message", "Inicio de sesión exitoso");
                        response.Add("Player", query.First());
                    }
                    else
                    {
                        response.Add("Message", "Correo o contraseña incorrectos. Por favor, verifíquelos");
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine(sqlEx.Message);
                }
                finally
                {
                    data.Dispose();
                }
            }
            else
            {
                response.Add("Message", Constants.ERROR_CONNECTION_MESSAGE);
            }

            return response;
        }
    }
}