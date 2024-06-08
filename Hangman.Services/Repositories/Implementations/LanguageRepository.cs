using Hangman.Services.Models.POCO;
using Hangman.Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using Hangman.Services.Utilities;
using System.Diagnostics;
using System.Data.SqlClient;
using Hangman.Services.Models.DTO;

namespace Hangman.Services.Repositories.Implementations
{

    public class LanguageRepository : ILanguageRepository
    {

        public Dictionary<string, object> GetLanguagesList()
        {
            Dictionary<string, object> response = new Dictionary<string, object>();

            using(DataContext dataSource = DBConnection.GetConnection())
            {

                if (dataSource != null)
                {

                    try
                    {
                        Table<Language> languageTable = dataSource.GetTable<Language>();

                        var languages = (from language in languageTable
                                        select new LanguageDTO
                                        {
                                            LanguageName = language.LanguageName
                                        }).ToList();

                        if (languages.Any())
                        {
                            response.Add("Data", languages);
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