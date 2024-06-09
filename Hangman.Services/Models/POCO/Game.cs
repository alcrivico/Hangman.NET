using System;
using System.Data.Linq.Mapping;

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
        public int ChallengerId { get; set; }

        [Column (Name = "WordId")]
        public int WordId { get; set; }

        [Column (Name = "LanguageId")]
        public int LanguageId { get; set; }

    }
}