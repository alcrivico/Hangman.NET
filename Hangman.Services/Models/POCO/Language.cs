using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using Hangman.Services.Models.DTO;
using System.Linq;
using System.Web;

namespace Hangman.Services.Models.POCO
{
    [Table (Name = "Language")]
    public class Language
    {
        [Column (Name = "Id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int LanguageId { get; set; }

        [Column (Name = "LanguageName")]
        public string LanguageName { get; set; }

    }
}