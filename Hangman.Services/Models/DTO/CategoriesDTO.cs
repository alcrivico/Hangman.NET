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
    public class CategoriesDTO
    {
        public static Dictionary<string, object> GetCategories()
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
                    Table<Category> categoryTable = data.GetTable<Category>();

                    var query = from category in categoryTable
                                select category;
                    if (query.Any())
                    {
                        response["Error"] = false;
                        response["Message"] = "Categorías encontradas";
                        response.Add("Categories", query.ToList());
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.Write(sqlEx.StackTrace);
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