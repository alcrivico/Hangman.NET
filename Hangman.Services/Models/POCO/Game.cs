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

        [Column (Name = "StatusId")]
        public int StatusId { get; set; }

        [Column (Name = "CreatorId")]
        public int CreatorId { get; set; }

        [Column(Name = "ChallengerId")]
        public int? ChallengerId { get; set; }

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

                    gameDTO.GameId = game.GameId;
                    gameDTO.CreationDate = game.CreationDate;
                    gameDTO.GameCode = game.GameCode;
                    gameDTO.StatusId = game.StatusId;
                    gameDTO.CreatorId = game.CreatorId;
                    gameDTO.ChallengerId = game.ChallengerId;

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

                gameDTO.GameId = game.GameId;
                gameDTO.CreationDate = game.CreationDate;
                gameDTO.GameCode = game.GameCode;
                gameDTO.StatusId = game.StatusId;
                gameDTO.CreatorId = game.CreatorId;
                gameDTO.ChallengerId = game.ChallengerId;

            }

            return gameDTO;
        }

        public static Game ConvertDTOToGame(GameDTO gameDTO)
        {
            Game game = new Game();

            if (gameDTO != null)
            {

                game.GameId = gameDTO.GameId;
                game.CreationDate = gameDTO.CreationDate;
                game.GameCode = gameDTO.GameCode;
                game.StatusId = gameDTO.StatusId;
                game.CreatorId = gameDTO.CreatorId;
                game.ChallengerId = gameDTO.ChallengerId;

            }

            return game;
        }

    }
}