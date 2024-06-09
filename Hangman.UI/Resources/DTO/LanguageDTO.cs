using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hangman.UI.Resources.DTO
{
    public class LanguageDTO
    {

        public required string LanguageName { get; set; }

        public override string ToString()
        {
            return LanguageName;
        }

    }
}