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
            Dictionary<string, object> response = new Dictionary<string, object>();
            DataContext data = DBConnection.GetConnection();

            if (data != null)
            {
                try
                {
                    Table<Player> playerTable = data.GetTable<Player>();

                    var player = from p in playerTable
                                where p.Id == playerId
                                select p;
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
    }
}