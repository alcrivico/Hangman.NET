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
    public class CategoryDTO
    {
        public static Dictionary<string, object> GetCategoriesList()
        {
            Dictionary<string, object> response = new Dictionary<string, object>();
            DataContext data = DBConnection.GetConnection();

            if (data != null)
            {
                try
                {
                    Table<Category> categoryTable = data.GetTable<Category>();

                    var categories = from category in categoryTable
                                select new
                                {
                                    category.CategoryES,
                                    category.CategoryEN
                                };
                    if (categories.Any())
                    {
                        response.Add("Result", 0);
                        response.Add("Data", categories.ToList());
                    }
                    else
                    {
                        response.Add("Result", 1);
                    }
                }
                catch (SqlException sqlEx)
                {
                    response.Add("Result", 2);
                    Console.WriteLine(sqlEx.Message);
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