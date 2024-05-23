using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace Hangman.Services.Models.POCO
{
    [Table (Name = "Game")]
    public class Game
    {
        [Column (Name = "IdGame", IsPrimaryKey = true, IsDbGenerated = true)]
        public int IdGame { get; set; }

        [Column (Name = "CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column (Name = "IdStatus")]
        public int IdStatus { get; set; }

        [Column (Name = "IdCreatorPlayer")]
        public int IdCreatorPlayer { get; set; }

        [Column (Name = "IdChallengerPlayer")]
        public int IdChallengerPlayer { get; set; }

        [Column (Name = "IdWord")]
        public int IdWord { get; set; }

        [Column (Name = "IdLanguage")]
        public int IdLanguage { get; set; }
    }
}