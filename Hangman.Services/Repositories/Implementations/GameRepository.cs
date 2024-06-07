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

        public List<Game> GetPlayedGames(string name)
        {
            

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
                            return null;
                        }

                        //Aqui tengo algunas dudar, ya que los join usualmente se realizan con los id, no se si hacerlo con el nombre del status sea correcto
                        var games = from game in gameTable
                                    join GameStatus in dataSource.GetTable<GameStatus>() on game.Status equals GameStatus.Status
                                    where (GameStatus.Status == "")
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
                                    where game.Status == ""
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

        public string GetPlayerType(string name, string gameCode)
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

                            if (game.ChallengerName == name)
                            {
                                return "Challenger";
                            }
                            else
                            {
                                return "Creator";
                            }

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

    }

}