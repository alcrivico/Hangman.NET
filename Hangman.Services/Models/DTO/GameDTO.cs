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
        public static Dictionary<string, object> CreateGame(Game newGame)
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

                    newGame.CreationDate = DateTime.Now;

                    gameTable.InsertOnSubmit(newGame);
                    data.SubmitChanges();

                    response["Error"] = false;
                    response["Message"] = "Partida creada exitosamente";
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
                                where game.IdChallengerPlayer == idPlayer &&
                                (game.IdStatus == 3 || 
                                    game.IdStatus == 4 ||
                                    game.IdStatus == 6)
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

        public static Dictionary<string, object> SetChallenger (int idGame, int idChallenger)
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
                            where game.IdGame == idGame
                            select game;
                if (query.Any())
                {
                    Game game = query.First();
                    game.IdChallengerPlayer = idChallenger;
                    data.SubmitChanges();

                    response["Error"] = false;
                    response["Message"] = "Partida aceptada";
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

        /*No jala, mejor comentarlo xd
        public static Dictionary<string, object> GetPlayerType(int playerId, int gameId)
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

                    var query = from game in gameTable
                                where game.IdGame == gameId
                                select game;

                    if (query.Any())
                    {
                        var game = query.First();

                        if(game.IdCreatorPlayer == playerId)
                        {
                            response["PlayerType"] = "Creator";
                        }
                        else if (game.IdChallengerPlayer == playerId)
                        {
                            response["PlayerType"] = "Challenger";
                        }
                        else
                        {
                            //No estoy del todo segura de si este es necesario, el jugador sera o un creador o un retador
                            response["PlayerType"] = "Unknown";
                        }

                        response["Error"] = false;
                        response["Message"] = "El tipo de jugador se ha recuperado de forma exitosa";
                    }
                    else
                    {
                        response["Message"] = "La partida no se ha encontrado";
                    }

                }
                catch (SqlException sqlEx)
                {
                    response["Message"] = "SQL Error: " + sqlEx.Message;
                }
                finally
                {
                    data.Dispose();
                }
            }
        }*/

    }
}