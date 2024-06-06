using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using Hangman.Services.Models.POCO;
using Hangman.Services.Repositories.Interfaces;
using Hangman.Services.Utilities;

namespace Hangman.Services.Repositories.Implementations
{

    public class CategoryRepository: ICategoryRepository
    {

        public List<Category> GetCategoriesList()
        {
            
            using(DataContext dataSource = DBConnection.GetConnection())
            {

                if (dataSource != null)
                {

                    try
                    {

                        Table<Category> categoryTable = dataSource.GetTable<Category>();
                        var categories = from category in categoryTable
                                        select new Category
                                        {

                                            CategoryId = category.CategoryId,
                                            CategoryES = category.CategoryES,
                                            CategoryEN = category.CategoryEN

                                        };

                        if (categories.Any())
                        {
                            return categories.ToList();
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