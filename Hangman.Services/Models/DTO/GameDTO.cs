using Hangman.Services.Models.POCO;
using Hangman.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hangman.Services.Models.DTO
{
    public class GameDTO
    {
        public static Dictionary<string, object> CreateGame(int playerId,int categoryId, int wordId)
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
                    Table<Game> gameTable = data.GetTable<Game>();

                    var newGame = new Game
                    {
                        CreationDate = DateTime.Now,
                        //idStatus =
                        IdCreatorPlayer = playerId,
                        IdWord = wordId,
                        //IdLanguage =
                    };

                    gameTable.InsertOnSubmit(newGame);
                    data.SubmitChanges();

                    response["Error"] = false;
                    response["Message"] = "Partida creada exitosamente";
                    response.Add("Game", newGame);
                }
                catch (SqlException sqlEx)
                {
                    response["Message"] = "Error al crear la partida: " + sqlEx.Message;
                }
                finally 
                { 
                    data.Dispose(); 
                }
            }

            return response;
        }

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

        public static Dictionary<string, object> SetGameStatus(int gameId, int StatusID)
        {
            Dictionary<string, object> response = new Dictionary<string, object>
            {
                { "Error", true },
                { "Message", "" }
            };
            DataContext data = DBConnection.GetConnection();

            if (data != null)
            {
                Table<Game> gameTable = data.GetTable<Game>();
                var query = from game in gameTable
                            where game.IdGame == gameId
                            select game;
                if (query.Any())
                {
                    Game game = query.First();
                    game.IdStatus = StatusID;
                    data.SubmitChanges();
                    response["Error"] = false;
                    response["Message"] = "Estado de la partida actualizado";
                    response.Add("Game", game);
                }
                else
                {
                    response["Message"] = "No se encontró la partida";
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