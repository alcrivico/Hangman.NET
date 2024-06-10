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

        public string LanguageName { get; set; }

        public int ResponseCode { get; set; }

        public string ToString()
        {
            return LanguageName;
        }
    }
}