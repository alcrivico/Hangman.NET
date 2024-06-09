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

        [Column (Name = "Id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column (Name = "CategoryES")]
        public string CategoryES { get; set; }

        [Column (Name = "CategoryEN")]
        public string CategoryEN { get; set; }

    }
}