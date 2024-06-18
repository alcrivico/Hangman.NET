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
using System.Security.Cryptography;

namespace Hangman.Services.Repositories.Implementations
{

    public class GameRepository : IGameRepository
    {
        public GameDTO CreateGame(GameDTO newGame)
        {

            GameDTO response = new GameDTO();

            using (YourDataContext dataSource = new YourDataContext(DBConnection.connectionString))
            {

                if (dataSource != null)
                {

                    try
                    {
                        Table<Game> gameTable = dataSource.GetTable<Game>();
                        Table<GameStatus> statusTable = dataSource.GetTable<GameStatus>();
                        Table<Player> playerTable = dataSource.GetTable<Player>();
                        Table<Word> wordTable = dataSource.GetTable<Word>();
                        Table<Language> languageTable = dataSource.GetTable<Language>();

                        var playerId = (from player in playerTable
                                        where player.Email == newGame.CreatorEmail
                                        select player.Id).First();

                        var wordId = (from word in wordTable
                                      where word.WordEN == newGame.Word || word.WordES == newGame.Word
                                      select word.Id).First();

                        var languageId = (from language in languageTable
                                          where language.LanguageName == newGame.Language
                                          select language.Id).First();

                        if (playerId != 0 && wordId != 0 && languageId != 0)
                        {
                            var games = (from game in gameTable
                                        join gameStatus in statusTable on game.StatusId equals gameStatus.Id
                                        join creator in playerTable on game.CreatorId equals creator.Id
                                        join word in wordTable on game.WordId equals word.Id
                                        join language in languageTable on game.LanguageId equals language.Id
                                        where playerId == game.CreatorId && wordId == game.WordId && languageId == game.LanguageId
                                        orderby game.CreationDate descending
                                        select new GameDTO
                                        {
                                            CreationDate = game.CreationDate,
                                            GameCode = game.GameCode,
                                            StatusEn = gameStatus.StatusEn,
                                            StatusEs = gameStatus.StatusEs,
                                            CreatorName = creator.Name,
                                            CreatorEmail = creator.Email,
                                            Word = (language.LanguageName == "English") ? word.WordEN : word.WordES,
                                            Language = language.LanguageName,
                                            ResponseCode = 0
                                        }).FirstOrDefault();
                            response = games;
                        }
                        else
                        {
                            response.ResponseCode = 1;
                        }


                    }
                    catch (SqlException sqlEx)
                    {
                        Debug.WriteLine("Error: " + sqlEx.Message + ": \n" + sqlEx.StackTrace);
                        response.ResponseCode = 2;
                    }

                }
                else
                {
                    response.ResponseCode = 3;
                }

            }

            return response;

        }

        public List<GameDTO> GetPlayedGames(string email)
        {

            List<GameDTO> response = new List<GameDTO>();
            GameDTO responseCode = new GameDTO();
            response.Add(responseCode);

            using (DataContext dataSource = DBConnection.GetConnection())
            {

                if (dataSource != null)
                {

                    try
                    {
                        Table<Game> gameTable = dataSource.GetTable<Game>();
                        Table<GameStatus> statusTable = dataSource.GetTable<GameStatus>();
                        Table<Player> playerTable = dataSource.GetTable<Player>();
                        Table<Word> wordTable = dataSource.GetTable<Word>();
                        Table<Language> languageTable = dataSource.GetTable<Language>();

                        var games = (from game in gameTable
                                join gameStatus in statusTable on game.StatusId equals gameStatus.Id
                                join creator in playerTable on game.CreatorId equals creator.Id
                                join challenger in playerTable on game.ChallengerId equals challenger.Id
                                join word in wordTable on game.WordId equals word.Id
                                join language in languageTable on game.LanguageId equals language.Id
                                where (gameStatus.StatusEn == "Won" || gameStatus.StatusEn == "Lost" || gameStatus.StatusEn == "Left")
                                && challenger.Email == email
                                select new GameDTO
                                {
                                    CreationDate = game.CreationDate,
                                    GameCode = game.GameCode,
                                    StatusEn = gameStatus.StatusEn,
                                    StatusEs = gameStatus.StatusEs,
                                    CreatorName = creator.Name,
                                    CreatorEmail = creator.Email,
                                    ChallengerName = challenger.Name,
                                    ChallengerEmail = challenger.Email,
                                    Word = (language.LanguageName == "English") ? word.WordEN : word.WordES,
                                    Language = language.LanguageName
                                }).ToList();

                        if (games.Any())
                        {
                            response = games;
                            response[0].ResponseCode = 0;
                        }
                        else
                        {
                            response[0].ResponseCode = 1;
                        }
                        
                    }
                    catch (SqlException sqlEx)
                    {
                        Debug.WriteLine("Error: " + sqlEx.Message + ": \n" + sqlEx.StackTrace);
                        response[0].ResponseCode = 2;
                    }
                }
                else
                {
                    response[0].ResponseCode = 3;
                }

            }

            return response;

        }

        public List<GameDTO> GetWaitingGames()
        {

            List<GameDTO> response = new List<GameDTO>();
            GameDTO responseCode = new GameDTO();
            response.Add(responseCode);

            using (DataContext dataSource = DBConnection.GetConnection())
            {

                if (dataSource != null)
                {

                    try
                    {

                        Table<Game> gameTable = dataSource.GetTable<Game>();
                        Table<GameStatus> statusTable = dataSource.GetTable<GameStatus>();
                        Table<Player> playerTable = dataSource.GetTable<Player>();
                        Table<Word> wordTable = dataSource.GetTable<Word>();
                        Table<Language> languageTable = dataSource.GetTable<Language>();
                        Table<Category> categoryTable = dataSource.GetTable<Category>();

                        var games = (from game in gameTable
                                     join gameStatus in statusTable on game.StatusId equals gameStatus.Id
                                     join creator in playerTable on game.CreatorId equals creator.Id
                                     join word in wordTable on game.WordId equals word.Id
                                     join language in languageTable on game.LanguageId equals language.Id
                                     where gameStatus.StatusEn == "Waiting"
                                     select new GameDTO
                                     {
                                         CreationDate = game.CreationDate,
                                         GameCode = game.GameCode,
                                         StatusEn = gameStatus.StatusEn,
                                         StatusEs = gameStatus.StatusEs,
                                         CreatorName = creator.Name,
                                         CreatorEmail = creator.Email,
                                         Word = (language.LanguageName == "English") ? word.WordEN : word.WordES,
                                         Language = language.LanguageName,
                                     }).ToList();

                        if (games.Any())
                        {
                            response = games;
                            response[0].ResponseCode = 0;
                        }
                        else
                        {
                            response[0].ResponseCode = 1;
                        }

                    }
                    catch (SqlException sqlEx)
                    {
                        Debug.WriteLine("Error: " + sqlEx.Message + ": \n" + sqlEx.StackTrace);
                        response[0].ResponseCode = 2;
                    }

                }
                else
                {
                    response[0].ResponseCode = 3;
                }

            }

            return response;

        }

        public GameDTO SetGameStatus(string gameCode, string status)
        {

            GameDTO response = new GameDTO();

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
                            Table<GameStatus> statusTable = dataSource.GetTable<GameStatus>();

                            var statusId = (from s in statusTable
                                            where s.StatusEn == status || s.StatusEs == status
                                            select s.Id).First();

                            game.StatusId = statusId;
                            dataSource.SubmitChanges();
                            response.ResponseCode = 0;

                        }
                        else
                        {
                            response.ResponseCode = 1;
                        }

                    }
                    catch (SqlException sqlEx)
                    {
                        Debug.WriteLine("Error: " + sqlEx.Message + ": \n" + sqlEx.StackTrace);
                        response.ResponseCode = 2;
                    }
                }
                else
                {
                    response.ResponseCode = 3;
                }

            }

            return response;

        }

        public GameDTO SetChallenger(string gameCode, string challengerEmail)
        {

            GameDTO response = new GameDTO();

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
                            Table<Player> playerTable = dataSource.GetTable<Player>();

                            var challengerId = (from challenger in playerTable
                                                where challenger.Email == challengerEmail
                                                select challenger.Id).First();

                            game.ChallengerId = challengerId; 
                            dataSource.SubmitChanges();
                            response.ResponseCode = 0;
                        }
                        else
                        {
                            response.ResponseCode = 1;
                        }

                    }
                    catch (SqlException sqlEx)
                    {
                        Debug.WriteLine("Error: " + sqlEx.Message + ": \n" + sqlEx.StackTrace);
                        response.ResponseCode = 2;
                    }

                }
                else
                {
                    response.ResponseCode = 1;
                }

            }

            return response;

        }

    }

}