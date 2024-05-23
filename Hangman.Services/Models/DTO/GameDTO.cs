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
    public class GameDTO
    {
        public static Dictionary<string, object> GetPlayedGames(int idPlayer)
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
                    Table<Game> gameTable = data.GetTable<Game>();

                    var query = from game in gameTable
                                where game.IdChallengerPlayer == idPlayer
                                select game;
                    if (query.Any())
                    {
                        response["Error"] = false;
                        response["Message"] = "Juegos jugados encontrados";
                        response.Add("Games", query.ToList());
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