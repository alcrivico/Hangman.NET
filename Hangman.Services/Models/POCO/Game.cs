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
        [Column (Name = "Id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column (Name = "CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column (Name = "GameCode")]
        public string GameCode { get; set; }

        [Column (Name = "StatusId")]
        public int StatusId { get; set; }

        [Column (Name = "CreatorId")]
        public int CreatorId { get; set; }

        [Column(Name = "ChallengerId")]
        public int? ChallengerIdNullable { get; set; }
        //Necesario para aceptar nulos
        public int ChallengerId
        {
            get { return ChallengerIdNullable ?? 0; }
            set { ChallengerIdNullable = value; }
        }

        [Column (Name = "WordId")]
        public int WordId { get; set; }

        [Column (Name = "LanguageId")]
        public int LanguageId { get; set; }

    }
}