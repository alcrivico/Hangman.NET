using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Hangman.Services.Models.DTO;
using Hangman.Services.Models.POCO;
using Hangman.Services.Repositories.Interfaces;
using Hangman.Services.Utilities;

namespace Hangman.Services.Repositories.Implementations
{

    public class CategoryRepository: ICategoryRepository
    {

        public Dictionary<string, object> GetCategoriesList()
        {
            Dictionary<string, object> response = new Dictionary<string, object>();

            using(DataContext dataSource = DBConnection.GetConnection())
            {

                if (dataSource != null)
                {

                    try
                    {

                        Table<Category> categoryTable = dataSource.GetTable<Category>();
                        var categories = from category in categoryTable
                                         select category;

                        if (categories.Any())
                        {
                            List<CategoryDTO> categoriesList = new List<CategoryDTO>();

                            foreach (Category category in categories.ToList())
                            {
                                CategoryDTO categoryDTO = new CategoryDTO
                                {
                                    CategoryEN = category.CategoryEN,
                                    CategoryES = category.CategoryES,
                                };

                                categoriesList.Add(categoryDTO);
                            }
                            response.Add("data", categoriesList);
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