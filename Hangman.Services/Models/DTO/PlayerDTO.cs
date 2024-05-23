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
                                where player.Email == email && player.Password == password
                                select player;
                    if (query.Any())
                    {
                        response["Error"] = false;
                        response["Message"] = "Inicio de sesión exitoso";
                        response.Add("Player", query.First());
                    }
                    else
                    {
                        response["Message"] = "Correo o contraseña incorrectos. Por favor, verifíquelos";
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

        public static Dictionary<string, object> SignUp(Player player)
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

                    var query = from p in playerTable
                                where p.Email == player.Email
                                select p;
                    if (!query.Any())
                    {
                        playerTable.InsertOnSubmit(player);
                        data.SubmitChanges();
                        response["Error"] = false;
                        response["Message"] = "Registro exitoso";
                    }
                    else
                    {
                        response["Message"] = "Ya existe un jugador registrado con ese correo electrónico";
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

        public static Dictionary<string, object> UpdateProfile (Player player)
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

                    var query = (from p in playerTable
                                where p.Email == player.Email
                                select p).First();

                    if (query != null)
                    {
                        query.Name = player.Name;
                        query.FirstLastName = player.FirstLastName;
                        query.SecondLastName = player.SecondLastName;
                        query.BirthDate = player.BirthDate;
                        query.Email = player.Email;
                        query.Password = player.Password;

                        data.SubmitChanges();
                        response["Error"] = false;
                        response["Message"] = "Perfil actualizado";
                        response.Add("Player", query);
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