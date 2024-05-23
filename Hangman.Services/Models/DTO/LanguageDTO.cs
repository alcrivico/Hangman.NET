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
        public static Dictionary<string, object> GetLanguages()
        {
            Dictionary<string, object> response = new Dictionary<string, object>
            {
                { "Error", true },
                { "Message", "" }
            };
            DataContext data = DBConnection.GetConnection();

            if (data != null)
            {
                try
                {
                    Table<Language> languageTable = data.GetTable<Language>();
                    var query = from language in languageTable
                                select language;
                    if (query.Any())
                    {
                        response["Error"] = false;
                        response["Message"] = "Idiomas obtenidos exitosamente";
                        response.Add("Languages", query.ToList());
                    }
                    else
                    {
                        response["Message"] = "No se encontraron idiomas";
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine(sqlEx.StackTrace);
                }
                finally
                {
                    data.Dispose();
                }
            }
            else
            {
                response["Message"] = Constants.ERROR_CONNECTION_MESSAGE;
            }
            return response;
        }
    }
}