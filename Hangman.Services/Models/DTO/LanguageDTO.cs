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
    public class LanguageDTO
    {
        //result 0 = correcto, 1 = sin datos, 2 sqlEx, 3 = error de conexion
        public static Dictionary<string, object> GetLanguagesList()
        {
            Dictionary<string, object> response = new Dictionary<string, object>();
            DataContext data = DBConnection.GetConnection();

            if (data != null)
            {
                try
                {
                    Table<Language> languageTable = data.GetTable<Language>();
                    var languages = from language in languageTable
                                select new
                                {
                                    language.LanguageName
                                };
                    if (languages.Any())
                    {
                        response.Add("Result", 0);
                        response.Add("Languages", languages.ToList());
                    }
                    else
                    {
                        response.Add("Result", 1);
                    }
                }
                catch (SqlException sqlEx)
                {
                    response.Add("Result", 2);
                    Console.WriteLine(sqlEx.StackTrace);
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