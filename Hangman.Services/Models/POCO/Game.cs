using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;
using Hangman.Services.Models.DTO;

namespace Hangman.Services.Models.POCO
{
    [Table (Name = "Game")]
    public class Game
    {
        [Column (Name = "Id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int GameId { get; set; }

        [Column (Name = "CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column (Name = "GameCode")]
        public string GameCode { get; set; }

        [Column (Name = "Status")]
        public string Status { get; set; }

        [Column (Name = "CreatorName")]
        public string CreatorName { get; set; }

        [Column(Name = "ChallengerName")]
        public string ChallengerName { get; set; }

        [Column (Name = "WordId")]
        public int WordId { get; set; }

        [Column (Name = "LanguageId")]
        public int LanguageId { get; set; }

    }
}