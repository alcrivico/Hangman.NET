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
                        Table<Category> categoryTable = dataSource.GetTable<Category>();

                        var words = (from word in wordTable
                                    join category in categoryTable
                                    on word.CategoryId equals category.CategoryId
                                    select new WordDTO
                                    {
                                        WordES = word.WordES,
                                        WordEN = word.WordEN,
                                        TipEN = word.TipEN,
                                        TipES = word.TipES,
                                        HasNumber = word.HasNumber,
                                        CategoryEN = category.CategoryEN,
                                        CategoryES = category.CategoryES,
                                    }).ToList();

                        if (words.Any())
                        {
                            response.Add("Data", words);
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