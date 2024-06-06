using Hangman.Services.Models.POCO;
using Hangman.Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using Hangman.Services.Utilities;

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
                                        select new Language
                                        {

                                            Id = language.Id,
                                            LanguageName = language.LanguageName

                                        };

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

                        Console.WriteLine(ex.StackTrace);
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