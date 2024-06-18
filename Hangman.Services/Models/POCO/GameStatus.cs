using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace Hangman.Services.Models.POCO
{
    [Table (Name = "GameStatus")]
    public class GameStatus
    {
        [Column (Name = "Id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column (Name = "StatusEs")]
        public string StatusEs { get; set; }

        [Column (Name = "StatusEn")]
        public string StatusEn { get; set; }
    }
}