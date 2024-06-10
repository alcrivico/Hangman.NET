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

        public List<CategoryDTO> GetCategoriesList()
        {
            List<CategoryDTO> response = new List<CategoryDTO>();
            CategoryDTO responseCode = new CategoryDTO();
            response.Add(responseCode);

            using (DataContext dataSource = DBConnection.GetConnection())
            {

                if (dataSource != null)
                {

                    try
                    {

                        Table<Category> categoryTable = dataSource.GetTable<Category>();
                        var categories = (from category in categoryTable
                                         select new CategoryDTO
                                         {
                                             CategoryES = category.CategoryES,
                                             CategoryEN = category.CategoryEN,
                                             ResponseCode = 0
                                         }).ToList();

                        if (categories.Any())
                        {
                            response = categories;
                        }
                        else
                        {
                            response[0].ResponseCode = 1;
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