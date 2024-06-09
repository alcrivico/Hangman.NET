using Hangman.Services.Models.DTO;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace Hangman.Services.Models.POCO
{
    [Table (Name = "Word")]
    public class Word
    {
        [Column (Name = "Id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column (Name = "WordES")]
        public string WordES { get; set; }

        [Column (Name = "WordEN")]
        public string WordEN { get; set; }

        [Column (Name  = "TipES")]
        public string TipES { get; set; }

        [Column (Name = "TipEN")]
        public string TipEN { get; set; }

        [Column (Name = "HasNumber")]
        public bool HasNumber { get; set; }

        [Column (Name = "Id")]
        public int CategoryId { get; set; }

    }
}