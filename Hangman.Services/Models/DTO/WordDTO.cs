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
            Dictionary<string, object> response = new Dictionary<string, object>();
            DataContext data = DBConnection.GetConnection();

            if (data != null)
            {
                try
                {
                    Table<Word> wordTable = data.GetTable<Word>();

                    var words = from word in wordTable
                                select new
                                {
                                    word.WordES,
                                    word.WordEN,
                                    word.TipES,
                                    word.TipEN,
                                    word.HasNumber,
                                    word.CategoryId
                                };
                    if (words.Any())
                    {
                        response.Add("Result", 0);
                        response.Add("Data", words.ToList());
                    }
                    else
                    {
                        response.Add("Result", 1);
                    }
                }
                catch (SqlException sqlEx)
                {
                    response.Add("Result", 2);
                    Console.Write(sqlEx.StackTrace);
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