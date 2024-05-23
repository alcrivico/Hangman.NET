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
        [Column (Name = "IdStatus", IsPrimaryKey = true, IsDbGenerated = true)]
        public int IdStatus { get; set; }

        [Column (Name = "Status")]
        public string Status { get; set; }
    }
}