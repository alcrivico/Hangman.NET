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

        public int GameId { get; set; }

        public DateTime CreationDate { get; set; }

        public string GameCode { get; set; }

        public int StatusId { get; set; }

        public int CreatorId { get; set; }

        public int? ChallengerId { get; set; }

        public int ResponseCode { get; set; }

    }
}