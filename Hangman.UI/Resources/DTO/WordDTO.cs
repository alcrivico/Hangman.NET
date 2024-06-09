using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hangman.UI.Resources.DTO
{

    public class WordDTO
    {

        public string WordES { get; set; }

        public string WordEN { get; set; }

        public string TipES { get; set; }

        public string TipEN { get; set; }

        public bool HasNumber { get; set; }

        public string CategoryES { get; set; }

        public string CategoryEN { get; set; }

    }

}