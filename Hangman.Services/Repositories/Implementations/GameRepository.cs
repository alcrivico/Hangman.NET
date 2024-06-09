using Hangman.Services.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hangman.Services.Repositories.Interfaces;
using System.Data.Linq;
using Hangman.Services.Utilities;
using System.Diagnostics;
using Hangman.Services.Models.DTO;
using System.Data.SqlClient;

namespace Hangman.Services.Repositories.Implementations
{

    public class GameRepository : IGameRepository
    {

        public Dictionary<string, object> CreateGame(GameDTO newGame)
        {

            Dictionary<string, object> response = new Dictionary<string, object>();

            using (YourDataContext dataSource = new YourDataContext(DBConnection.connectionString))
            {

                if (dataSource != null)
                {

                    try
                    {
                        Table<Player> playerTable = dataSource.GetTable<Player>();
                        Table<Word> wordTable = dataSource.GetTable<Word>();
                        Table<Language> languageTable = dataSource.GetTable<Language>();

                        var playerId = (from player in playerTable
                                       where player.Name == newGame.CreatorName
                                       select player.PlayerId).SingleOrDefault();

                        var wordId = (from word in wordTable
                                     where word.WordEN == newGame.Word || word.WordES == newGame.Word
                                     select word.WordId).SingleOrDefault();

                        var languageId = (from language in languageTable
                                         where language.LanguageName == newGame.Language
                                         select language.LanguageId).SingleOrDefault();

                        if(playerId != 0 && wordId != 0 && languageId != 0)
                        {
                            dataSource.AddGame(playerId, wordId, languageId);
                            response.Add("ResponseCode", 0);
                        }
                        else
                        {
                            response.Add("ResponseCode", 1);
                        }
                        

                    }
                    catch (SqlException sqlEx)
                    {
                        Debug.WriteLine("Error: " + sqlEx.Message + ": \n" + sqlEx.StackTrace);
                        response.Add("ResponseCode", 2);
                    }

                }
                else
                {
                    response.Add("ResponseCode", 3);
                }

            }

            return response;

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

                        var games = (from game in gameTable
                                    join GameStatus in dataSource.GetTable<GameStatus>() on game.Status equals GameStatus.Status
                                    where (GameStatus.Status == "Won" || GameStatus.Status == "Lost" || GameStatus.Status == "Left")
                                    select game).ToList();
                        
                        if (games.Any())
                        {
                            response.Add("Dara", games);
                            response.Add("ResponseCode", 0);
                        }
                        else
                        {
                            response.Add("ResponseCode", 1);
                        }

                    }
                    catch (SqlException sqlEx)
                    {
                        Debug.WriteLine("Error: " + sqlEx.Message + ": \n" + sqlEx.StackTrace);
                        response.Add("ResponseCode", 2);
                    }
                }
                else
                {
                    response.Add("ResponseCode", 3);
                }

            }

            return response;

        }

        public Dictionary<string, object> GetWaitingGames()
        {

            Dictionary<string, object> response = new Dictionary<string, object>();

            using (DataContext dataSource = DBConnection.GetConnection())
            {

                if (dataSource != null)
                {

                    try
                    {

                        Table<Game> gameTable = dataSource.GetTable<Game>();
                        var games = (from game in gameTable
                                    where game.Status == "Waiting"
                                    select game).ToList();

                        if (games.Any())
                        {
                            response.Add("Data", games);
                            response.Add("ResponseCode", 0);
                        }
                        else
                        {
                            response.Add("ResponseCode", 1);
                        }

                    }
                    catch (SqlException sqlEx)
                    {
                        Debug.WriteLine("Error: " + sqlEx.Message + ": \n" + sqlEx.StackTrace);
                        response.Add("ResponseCode", 2);
                    }

                }
                else
                {
                    response.Add("ResponseCode", 3);
                }

            }

            return response;

        }

        public Dictionary<string, object> SetGameStatus(string gameCode, string status)
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
                                    select g).First();

                        if (game != null)
                        {

                            game.Status = status;
                            dataSource.SubmitChanges();

                            response.Add("ResponseCode", 0);

                        }
                        else
                        {
                            response.Add("ResponseCode", 1);
                        }

                    }
                    catch (Exception ex)
                    {

                        Debug.WriteLine("Error: " + ex.Message + ": \n" + ex.StackTrace);
                        response.Add("ResponseCode", 2);

                    }

                }
                else
                {
                    response.Add("ResponseCode", 3);
                }

            }

            return response;

        }

        public Dictionary<string, object> SetChallenger(string gameCode, string challengerName)
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
                                    select g).First();

                        if (game != null)
                        {
                            game.ChallengerName = challengerName;
                            dataSource.SubmitChanges();

                            response.Add("ResponseCode", 0);
                        }
                        else
                        {
                            response.Add("ResponseCode", 1);
                        }

                    }
                    catch (SqlException sqlEx)
                    {
                        Debug.WriteLine("Error: " + sqlEx.Message + ": \n" + sqlEx.StackTrace);
                        response.Add("ResponseCode", 2);
                    }

                }
                else
                {
                    response.Add("ResponseCode", 3);
                }

            }

            return response;

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

                            response.Add("data", playerType);
                            response.Add("ResponseCode", 0);

                        }
                        else
                        {
                            response.Add("ResponseCode", 1);
                        }

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error: " + ex.Message + ": \n" + ex.StackTrace);
                        response.Add("ResponseCode", 2);
                    }

                }
                else
                {
                    response.Add("ResponseCode", 3);
                }

            }
            return response;
        }

    }

}