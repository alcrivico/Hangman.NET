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
    public class WordDTO
    {
        public static Dictionary<string, object> GetWordsList()
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
                    Table<Word> wordTable = data.GetTable<Word>();

                    var query = from word in wordTable
                                select word;
                    if (query.Any())
                    {
                        response["Error"] = false;
                        response["Message"] = "Palabras encontradas";
                        response.Add("Words", query.ToList());
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.Write(sqlEx.StackTrace);
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