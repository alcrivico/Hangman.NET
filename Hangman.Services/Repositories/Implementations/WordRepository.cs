using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Hangman.Services.Models.DTO;
using Hangman.Services.Models.POCO;
using Hangman.Services.Repositories.Interfaces;
using Hangman.Services.Utilities;

namespace Hangman.Services.Repositories.Implementations
{

    public class WordRepository : IWordRepository
    {

        public Dictionary<string, object> GetWordsList()
        {
            Dictionary<string, object> response = new Dictionary<string, object>();

            using (DataContext dataSource = DBConnection.GetConnection())
            {

                if (dataSource != null)
                {

                    try
                    {

                        Table<Word> wordTable = dataSource.GetTable<Word>();

                        var words = from word in wordTable
                                    select word;

                        if (words.Any())
                        {
                            foreach (Word word in words.ToList())
                            {
                                WordDTO wordDTO = new WordDTO()
                                {
                                    WordEN = word.WordEN,
                                    WordES = word.WordES,
                                    TipEN = word.TipEN,
                                    TipES = word.TipES,
                                    HasNumber = word.HasNumber,

                                };
                            }

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

    }

}