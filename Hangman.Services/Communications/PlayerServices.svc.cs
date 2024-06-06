using Hangman.Services.Models.DTO;
using Hangman.Services.Models.POCO;
using Hangman.Services.Repositories.Interfaces;
using Hangman.Services.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Hangman.Services.Communications
{

    public class PlayerServices : IPlayerServices
    {

        private IPlayerRepository _playerRepository;
        private IGameRepository _gameRepository;

        public PlayerServices(IPlayerRepository playerRepository, IGameRepository gameRepository)
        {

            _playerRepository = playerRepository;
            _gameRepository = gameRepository;

        }

        public PlayerServices()
        {
            _playerRepository = new PlayerRepository();
            _gameRepository = new GameRepository();
        }

        public PlayerDTO LogIn (string email, string pass)
        {

            Player playerAnswer = _playerRepository.LogIn(email, pass);

            return Player.ConvertPlayerToDTO(playerAnswer);

        }

        public PlayerDTO SignUp(Player player)
        {
            
            Player playerAnswer = _playerRepository.SignUp(player);

            return Player.ConvertPlayerToDTO(playerAnswer);

        }

        public PlayerDTO UpdateProfile(Player player)
        {

            Player playerAnswer = _playerRepository.UpdateProfile(player);

            return Player.ConvertPlayerToDTO(playerAnswer);

        }

        public List<GameDTO> GetPlayedGames(int idPlayer)
        {

            List<Game> playedGames = _gameRepository.GetPlayedGames(idPlayer);

            return Game.ConvertGameListToDTO(playedGames);

        }

    }
}
