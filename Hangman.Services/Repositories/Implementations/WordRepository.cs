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

        public List<WordDTO> GetWordsList()
        {
            List<WordDTO> response = new List<WordDTO>();
            WordDTO responseCode = new WordDTO();
            response.Add(responseCode);

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
                                    on word.CategoryId equals category.Id
                                    select new WordDTO
                                    {
                                        WordES = word.WordES,
                                        WordEN = word.WordEN,
                                        TipEN = word.TipEN,
                                        TipES = word.TipES,
                                        HasNumber = word.HasNumber,
                                        CategoryEN = category.CategoryEN,
                                        CategoryES = category.CategoryES,
                                        ResponseCode = 0
                                    }).ToList();

                        if (words.Any())
                        {
                            response = words;
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

        public WordDTO SearchWord(string word)
        {
            WordDTO response = new WordDTO();

            using (DataContext dataSource = DBConnection.GetConnection())
            {

                if (dataSource != null)
                {

                    try
                    {

                        Table<Word> wordTable = dataSource.GetTable<Word>();
                        Table<Category> categoryTable = dataSource.GetTable<Category>();

                        var foundWord = (from wordRow in wordTable
                                    join category in categoryTable
                                    on wordRow.CategoryId equals category.Id
                                    where wordRow.WordEN == word || wordRow.WordES == word
                                    select new WordDTO
                                    {
                                        WordES = wordRow.WordES,
                                        WordEN = wordRow.WordEN,
                                        TipEN = wordRow.TipEN,
                                        TipES = wordRow.TipES,
                                        HasNumber = wordRow.HasNumber,
                                        CategoryEN = category.CategoryEN,
                                        CategoryES = category.CategoryES,
                                        ResponseCode = 0
                                    }).FirstOrDefault();

                        if (foundWord != null)
                        {
                            response = foundWord;
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

    }

}