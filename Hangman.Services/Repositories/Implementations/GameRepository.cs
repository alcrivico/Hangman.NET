using Hangman.Services.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hangman.Services.Repositories.Interfaces;
using System.Data.Linq;
using Hangman.Services.Utilities;
using System.Diagnostics;

namespace Hangman.Services.Repositories.Implementations
{

    public class GameRepository : IGameRepository
    {

        public Game CreateGame(Game newGame)
        {
            
            using(DataContext dataSource = DBConnection.GetConnection())
            {

                if (dataSource != null)
                {

                    try
                    {

                        Table<Game> gameTable = dataSource.GetTable<Game>();
                        newGame.CreationDate = DateTime.Now;

                        gameTable.InsertOnSubmit(newGame);
                        dataSource.SubmitChanges();

                        return newGame;

                    }
                    catch (Exception ex)
                    {

                        Debug.WriteLine("Error: " + ex.Message + ": \n" + ex.StackTrace);

                        return null;

                    }

                }
                else
                {
                    return null;
                }

            }

        }

        public Dictionary<string, object> GetPlayedGames(string name)
        {

            Dictionary<string, object> response = new Dictionary<string, object>();

            using (DataContext dataSource = DBConnection.GetConnection())
            {

                if (dataSource != null)
                {

                    try
                    {

                        Table<Game> gameTable = dataSource.GetTable<Game>();

                        var player = (from p in dataSource.GetTable<Player>()
                                      where p.Name == name
                                      select p).FirstOrDefault();

                        if (player == null)
                        {
                            response.Add("responseCode", 1);
                            return response;
                        }

                        //Aqui tengo algunas dudar, ya que los join usualmente se realizan con los id, no se si hacerlo con el nombre del status sea correcto
                        var games = from game in gameTable
                                    join GameStatus in dataSource.GetTable<GameStatus>() on game.Status equals GameStatus.Status
                                    where (GameStatus.Status == "Won" || GameStatus.Status == "Lost" || GameStatus.Status == "Left")
                                    select game;
                        
                        if (games.Any())
                        {
                            response.Add("games", games.ToList());
                            response.Add("responseCode", 0);
                        }
                        else
                        {
                            response.Add("responseCode", 2);
                        }

                    }
                    catch (Exception ex)
                    {

                        Debug.WriteLine("Error: " + ex.Message + ": \n" + ex.StackTrace);
                        response.Add("responseCode", 3);

                    }

                }
                else
                {
                    response.Add("responseCode", 4);
                }

            }

            return response;

        }

        public List<Game> GetWaitingGames()
        {
            
            using (DataContext dataSource = DBConnection.GetConnection())
            {

                if (dataSource != null)
                {

                    try
                    {

                        Table<Game> gameTable = dataSource.GetTable<Game>();
                        var games = from game in gameTable
                                    where game.Status == "Waiting"
                                    select game;

                        if (games.Any())
                        {
                            return games.ToList();
                        }
                        else
                        {
                            return null;
                        }

                    }
                    catch (Exception ex)
                    {

                        Debug.WriteLine("Error: " + ex.Message + ": \n" + ex.StackTrace);

                        return null;

                    }

                }
                else
                {
                    return null;
                }

            }

        }

        public Game SetGameStatus(string gameCode, string status)
        {
            
            using(DataContext dataSource = DBConnection.GetConnection())
            {

                if (dataSource != null)
                {

                    try
                    {

                        Table<Game> gameTable = dataSource.GetTable<Game>();

                        var game = (from g in gameTable
                                    where g.GameCode == gameCode
                                    select g).First();

                        if (game != null)
                        {

                            game.Status = status;

                            dataSource.SubmitChanges();
                            
                            return game;

                        }
                        else
                        {
                            return null;
                        }

                    }
                    catch (Exception ex)
                    {

                        Debug.WriteLine("Error: " + ex.Message + ": \n" + ex.StackTrace);

                        return null;

                    }

                }
                else
                {
                    return null;
                }

            }

        }

        public Game SetChallenger(string gameCode, string challengerName)
        {
            
            using(DataContext dataSource = DBConnection.GetConnection())
            {

                if (dataSource != null)
                {

                    try
                    {

                        Table<Game> gameTable = dataSource.GetTable<Game>();

                        var game = (from g in gameTable
                                    where g.GameCode == gameCode
                                    select g).First();

                        if (game != null)
                        {

                            game.ChallengerName = challengerName;

                            dataSource.SubmitChanges();

                            return game;

                        }
                        else
                        {
                            return null;
                        }

                    }
                    catch (Exception ex)
                    {

                        Debug.WriteLine("Error: " + ex.Message + ": \n" + ex.StackTrace);

                        return null;

                    }

                }
                else
                {
                    return null;
                }

            }

        }

        public Dictionary<string, object> GetPlayerType(string name, string gameCode)
        {

            Dictionary<string, object> response = new Dictionary<string, object>();

            using (DataContext dataSource = DBConnection.GetConnection())
            {

                if (dataSource != null)
                {

                    try
                    {

                        Table<Game> gameTable = dataSource.GetTable<Game>();
                        var game = (from g in gameTable
                                    where g.GameCode == gameCode
                                    select g).FirstOrDefault();

                        if (game != null)
                        {

                            string playerType;
                            if (game.ChallengerName == name)
                            {
                                playerType = "Challenger";
                            }
                            else
                            {
                                playerType = "Creator";
                            }

                            response.Add("playerType", playerType);
                            response.Add("ResponseCode", 0);

                        }
                        else
                        {
                            response.Add("responseCode", 1);
                        }

                    }
                    catch (Exception ex)
                    {

                        Debug.WriteLine("Error: " + ex.Message + ": \n" + ex.StackTrace);
                        response.Add("responseCode", 2);
                        

                    }

                }
                else
                {
                    response.Add("responseCode", 3);
                }

            }

            return response;

        }

    }

}