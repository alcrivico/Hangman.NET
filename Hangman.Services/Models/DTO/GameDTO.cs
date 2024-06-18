using Hangman.Services.Models.POCO;
using Hangman.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hangman.Services.Models.DTO
{
    public class GameDTO
    {

        public DateTime CreationDate { get; set; }

        public string GameCode { get; set; }

        public string StatusEn { get; set; }

        public string StatusEs { get; set; }

        public string CreatorName { get; set; }
        
        public string CreatorEmail { get; set; }

        public int WaitingTime { get; set; }

        public string ChallengerName { get; set; }

        public string ChallengerEmail { get; set; }

        public string Word { get; set; }

        public string Language { get; set; }

        public int ResponseCode { get; set; }

    }
}