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

        public List<LanguageDTO> GetLanguagesList()
        {
            List<LanguageDTO> response = new List<LanguageDTO>();
            LanguageDTO responseCode = new LanguageDTO();
            response.Add(responseCode);

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
                                            LanguageName = language.LanguageName,
                                            ResponseCode = 0
                                        }).ToList();

                        if (languages.Any())
                        {
                            response = languages;
                        }
                        else
                        {
                            response[0].ResponseCode=1;
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

    }

}