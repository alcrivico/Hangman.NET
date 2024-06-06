using Hangman.Services.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace Hangman.Services.Models.POCO
{
    [Table (Name = "Category")]
    public class Category
    {

        [Column (Name = "IdCategory", IsPrimaryKey = true, IsDbGenerated = true)]
        public int CategoryId { get; set; }

        [Column (Name = "CategoryES")]
        public string CategoryES { get; set; }

        [Column (Name = "CategoryEN")]
        public string CategoryEN { get; set; }

        public static List<CategoryDTO> ConvertCategoryListToDTO(List<Category> categories)
        {

            List<CategoryDTO> categoriesDTO = new List<CategoryDTO>();

            foreach (Category category in categories)
            {

                CategoryDTO categoryDTO = new CategoryDTO();

                categoryDTO.CategoryId = category.CategoryId;
                categoryDTO.CategoryES = category.CategoryES;
                categoryDTO.CategoryEN = category.CategoryEN;

                categoriesDTO.Add(categoryDTO);

            }

            return categoriesDTO;

        }

    }
}