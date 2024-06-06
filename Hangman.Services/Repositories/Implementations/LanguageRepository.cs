using Hangman.Services.Models.POCO;
using Hangman.Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using Hangman.Services.Utilities;
using System.Diagnostics;

namespace Hangman.Services.Repositories.Implementations
{

    public class LanguageRepository : ILanguageRepository
    {

        public List<Language> GetLanguagesList()
        {

            using(DataContext dataSource = DBConnection.GetConnection())
            {

                if (dataSource != null)
                {

                    try
                    {

                        Table<Language> languageTable = dataSource.GetTable<Language>();
                        var languages = from language in languageTable
                                        select language;

                        if (languages.Any())
                        {
                            return languages.ToList();
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