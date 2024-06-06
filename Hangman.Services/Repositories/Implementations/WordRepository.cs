using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using Hangman.Services.Models.POCO;
using Hangman.Services.Repositories.Interfaces;
using Hangman.Services.Utilities;

namespace Hangman.Services.Repositories.Implementations
{

    public class WordRepository : IWordRepository
    {

        public List<Word> GetWordsList()
        {

            using (DataContext dataSource = DBConnection.GetConnection())
            {

                if (dataSource != null)
                {

                    try
                    {

                        Table<Word> wordTable = dataSource.GetTable<Word>();

                        var words = from word in wordTable
                                    select new Word
                                    {
                                        WordES = word.WordES,
                                        WordEN = word.WordEN,
                                        TipES = word.TipES,
                                        TipEN = word.TipEN,
                                        HasNumber = word.HasNumber,
                                        CategoryId = word.CategoryId
                                    };

                        return words.ToList();

                    }
                    catch (Exception ex)
                    {

                        Console.Write("Error: " + ex.StackTrace);

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