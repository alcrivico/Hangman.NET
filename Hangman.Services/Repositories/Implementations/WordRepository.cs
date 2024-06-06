using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
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
                                    select word;

                        if (words.Any())
                        {
                            return words.ToList();
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