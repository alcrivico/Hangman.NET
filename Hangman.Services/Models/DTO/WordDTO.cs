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

    public class WordDTO
    {
        public int WordId { get; set; }

        public string WordES { get; set; }

        public string WordEN { get; set; }

        public string TipES { get; set; }

        public string TipEN { get; set; }

        public bool HasNumber { get; set; }

        public int CategoryId { get; set; }

        public int ResponseCode { get; set; }

    }

}