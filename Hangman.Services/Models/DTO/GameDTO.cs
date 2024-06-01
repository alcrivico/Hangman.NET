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
            Dictionary<string, object> response = new Dictionary<string, object>();
            DataContext data = DBConnection.GetConnection();

            if (data != null)
            {
                try
                {
                    Table<Game> gameTable = data.GetTable<Game>();

                    newGame.CreationDate = DateTime.Now;

                    gameTable.InsertOnSubmit(newGame);
                    data.SubmitChanges();

                    response.Add("Result", 0);
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
        //Corregir: conseguirlos por email no id, y game status por nombre no id
        public static Dictionary<string, object> GetPlayedGames(int idPlayer)
        {
            Dictionary<string, object> response = new Dictionary<string, object>();
            DataContext data = DBConnection.GetConnection();

            if (data != null)
            {
                try
                {
                    Table<Player> playerTable = data.GetTable<Player>();
                    Table<Game> gameTable = data.GetTable<Game>();
                    Table<GameStatus> gameStatusTable = data.GetTable<GameStatus>();

                    var games = from game in gameTable
                                where game.ChallengerId == idPlayer &&
                                (game.StatusId == 3 || 
                                    game.StatusId == 4 ||
                                    game.StatusId == 6)
                                select game;
                    if (games.Any())
                    {
                        response.Add("Result", 0);
                        response.Add("Data", games.ToList());
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

        //Corregir: status por nombre, no id
        public static Dictionary<string, object> GetWaitingGames()
        {
            Dictionary<string, object> response = new Dictionary<string, object>();
            DataContext data = DBConnection.GetConnection();

            if (data != null)
            {
                try
                {
                    Table<Game> gameTable = data.GetTable<Game>();
                    var games = from game in gameTable
                                where game.StatusId == 1
                                select game;
                    if (games.Any())
                    {
                        response.Add("Result", 0);
                        response.Add("Data", games.ToList());
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
        //Corregir: no usar StatusId, usar nombres
        public static Dictionary<string, object> SetGameStatus(string gameCode, int StatusID)
        {
            Dictionary<string, object> response = new Dictionary<string, object>();
            DataContext data = DBConnection.GetConnection();

            if (data != null)
            {
                try
                {
                    Table<Game> gameTable = data.GetTable<Game>();
                    var game = (from g in gameTable
                                where g.GameCode == gameCode
                                select g).First();
                    if (game != null)
                    {
                        game.StatusId = StatusID;
                        data.SubmitChanges();
                        response.Add("Result", 0);
                    }
                    else
                    {
                        response.Add("Result", 1);
                    }
                }
                catch(SqlException sqlEx)
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
        
        //Corregir: no usar idChallenger, usar nombres
        public static Dictionary<string, object> SetChallenger (string gameCode, int idChallenger)
        {
            Dictionary<string, object> response = new Dictionary<string, object>();
            DataContext data = DBConnection.GetConnection();

            if (data != null)
            {
                try
                {
                    Table<Game> gameTable = data.GetTable<Game>();
                    var game = (from g in gameTable
                                where g.GameCode == gameCode
                                select g).First();
                    if (game != null)
                    {
                        game.ChallengerId = idChallenger;
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
        //Corregir: no usar playerId, usar nombres
        public static Dictionary<string, object> GetPlayerType(int playerId, string gameCode)
        {
            Dictionary<string, object> response = new Dictionary<string, object>();
            DataContext data = DBConnection.GetConnection();

            if (data != null)
            {
                try
                {
                    Table<Game> gameTable = data.GetTable<Game>();
                    var query = from game in gameTable
                                where game.GameCode == gameCode
                                select game;

                    if (query.Any())
                    {
                        var game = query.First();

                        if(game.CreatorId == playerId)
                        {
                            response.Add("Data", "Creator");
                        }
                        else
                        {
                            response.Add("Data", "Challenger");
                        }

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

    }
}