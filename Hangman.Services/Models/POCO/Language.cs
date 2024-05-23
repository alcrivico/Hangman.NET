using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace Hangman.Services.Models.POCO
{
    [Table (Name = "Language")]
    public class Language
    {
        [Column (Name = "IdLanguage", IsPrimaryKey = true, IsDbGenerated = true)]
        public int IdLanguage { get; set; }

        [Column (Name = "LanguageName")]
        public string LanguageName { get; set; }
    }
}