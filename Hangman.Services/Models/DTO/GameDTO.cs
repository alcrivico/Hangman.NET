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
        }
    }
}