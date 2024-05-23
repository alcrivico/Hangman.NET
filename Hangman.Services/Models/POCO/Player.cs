using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace Hangman.Services.Models.POCO
{
    [Table (Name = "Player")]
    public class Player
    {
        [Column (Name = "IdPlayer", IsPrimaryKey = true, IsDbGenerated = true)]
        public int IdPlayer { get; set; }

        [Column (Name = "Name")]
        public string Name { get; set; }

        [Column (Name = "FirstLastName")]
        public string FirstLastName { get; set; }

        [Column (Name = "SecondLastName")]
        public string SecondLastName { get; set; }

        [Column (Name = "BirthDate")]
        public DateTime BirthDate { get; set; }

        [Column (Name = "Email")]
        public string Email { get; set; }

        [Column (Name = "Password")]
        public string Password { get; set; }
    }
}