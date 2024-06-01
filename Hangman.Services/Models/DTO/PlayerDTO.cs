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
        //result 0 = correcto, 1 = sindatos/existente, 2 = sqlEx, 3 = error de conexion
        public static Dictionary<string, object> LogIn(string email, string password)
        {
            Dictionary<string, object> response = new Dictionary<string, object>();
            DataContext data = DBConnection.GetConnection();

            if (data != null)
            {
                try
                {
                    Table<Player> playerTable = data.GetTable<Player>();

                    var player = from p in playerTable
                                where p.Email == email && p.Password == password
                                select new
                                {
                                    p.FirstName,
                                    p.FirstLastName,
                                    p.SecondLastName,
                                    p.BirthDate,
                                    p.Email
                                };
                    if (player.Any())
                    {
                        response.Add("Result", 0);
                        response.Add("Data", player.First());
                    }
                    else
                    {
                        response.Add("Result", 1);
                    }
                }
                catch (SqlException sqlEx)
                {
                    response.Add("Result", 2);
                    Console.WriteLine(sqlEx.StackTrace);
                }
                finally
                {
                    data.Dispose();
                }
            }
            else
            {
                response.Add("Result", 3);
            }
            return response;
        }

        public static Dictionary<string, object> SignUp(Player newPlayer)
        {
            Dictionary<string, object> response = new Dictionary<string, object>();
            DataContext data = DBConnection.GetConnection();

            if (data != null)
            {
                try
                {
                    Table<Player> playerTable = data.GetTable<Player>();

                    var player = from p in playerTable
                                where p.Email == newPlayer.Email
                                select p;
                    if (!player.Any())
                    {
                        playerTable.InsertOnSubmit(newPlayer);
                        data.SubmitChanges();
                        response.Add("Result", 0);
                    }
                    else
                    {
                        response.Add("Result", 1);
                    }
                }
                catch (SqlException sqlEx)
                {
                    response.Add("Result", 2);
                    Console.WriteLine(sqlEx.StackTrace);
                }
                finally
                {
                    data.Dispose();
                }
            }
            else
            {
                response.Add("Result", 3);
            }
            return response;
        }

        public static Dictionary<string, object> UpdateProfile (Player updatedPlayer)
        {
            Dictionary<string, object> response = new Dictionary<string, object>();
            DataContext data = DBConnection.GetConnection();

            if (data != null)
            {
                   try
                {
                    Table<Player> playerTable = data.GetTable<Player>();

                    var player = (from p in playerTable
                                 where p.Email == updatedPlayer.Email
                                 select p).First();

                    if (player != null)
                    {
                        player.FirstName = updatedPlayer.FirstName;
                        player.FirstLastName = updatedPlayer.FirstLastName;
                        player.SecondLastName = updatedPlayer.SecondLastName;
                        player.BirthDate = updatedPlayer.BirthDate;
                        player.Password = updatedPlayer.Password;

                        data.SubmitChanges();
                        response.Add("Result", 0);
                    }
                    else
                    {
                        response.Add("Result", 1);
                    }
                }
                catch (SqlException sqlEx)
                {
                    response.Add("Result", 2);
                    Console.WriteLine(sqlEx.StackTrace);
                }
                finally
                {
                    data.Dispose();
                }
            }
            else
            {
                response.Add("Result", 3);
            }
            return response;
        }

        public static Dictionary<string, object> GetPlayerById(int playerId)
        {
            Dictionary<string, object> response = new Dictionary<string, object>
            {
                { "Error", true },
                { "Message", "" }
            };
            DataContext data = DBConnection.GetConnection();

            if (data != null)
            {
                try
                {
                    Table<Player> playerTable = data.GetTable<Player>();

                    var query = from player in playerTable
                                where player.Id == playerId
                                select player;
                    if (query.Any())
                    {
                        response["Error"] = false;
                        response["Message"] = "Jugador encontrado";
                        response.Add("Player", query.First());
                    }
                    else
                    {
                        response["Message"] = "No se encontró al jugador";
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine(sqlEx.StackTrace);
                }
                finally
                {
                    data.Dispose();
                }
            }
            else
            {
                response["Message"] = Constants.ERROR_CONNECTION_MESSAGE;
            }
            return response;
        }
    }
}