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


        public static List<GameDTO> ConvertGameListToDTO(List<Game> games)
        {

            List<GameDTO> gamesDTO = new List<GameDTO>();

            if (games != null)
            {

                foreach (Game game in games)
                {

                    GameDTO gameDTO = new GameDTO();

                    gameDTO.CreationDate = game.CreationDate;
                    gameDTO.GameCode = game.GameCode;
                    gameDTO.Status = game.Status;
                    gameDTO.CreatorName = game.CreatorName;
                    gameDTO.ChallengerName = game.ChallengerName;

                    gamesDTO.Add(gameDTO);

                }

            }

            return gamesDTO;

        }

        public static GameDTO ConvertGameToDTO(Game game)
        {
            GameDTO gameDTO = new GameDTO();

            if (game != null)
            {

                gameDTO.CreationDate = game.CreationDate;
                gameDTO.GameCode = game.GameCode;
                gameDTO.Status = game.Status;
                gameDTO.CreatorName = game.CreatorName;
                gameDTO.ChallengerName = game.ChallengerName;

            }

            return gameDTO;
        }

        public static Game ConvertDTOToGame(GameDTO gameDTO)
        {
            Game game = new Game();

            if (gameDTO != null)
            {

                game.CreationDate = gameDTO.CreationDate;
                game.GameCode = gameDTO.GameCode;
                game.Status = gameDTO.Status;
                game.CreatorName = gameDTO.CreatorName;
                game.ChallengerName = gameDTO.ChallengerName;

            }

            return game;
        }

    }
}