using Hangman.Services.Models.DTO;
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
        [Column (Name = "Id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int PlayerId { get; set; }

        [Column (Name = "FirstName")]
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

        public static PlayerDTO ConvertPlayerToDTO(Player player)
        {

            PlayerDTO playerDTO = new PlayerDTO();

            if (player != null)
            {

                playerDTO.Name = player.Name;
                playerDTO.FirstLastName = player.FirstLastName;
                playerDTO.SecondLastName = player.SecondLastName;
                playerDTO.BirthDate = player.BirthDate;
                playerDTO.Email = player.Email;

            }

            return playerDTO;
        }

    }
}