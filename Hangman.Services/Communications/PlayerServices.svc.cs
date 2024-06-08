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

        public Dictionary<string, object> LogIn (string email, string pass)
        {
            return _playerRepository.LogIn(email, pass);
        }

        public Dictionary<string, object> SignUp(PlayerDTO player)
        {
            return _playerRepository.SignUp(player);
        }

        public Dictionary<string, object> UpdateProfile(PlayerDTO player)
        {
            return _playerRepository.UpdateProfile(player);
        }

        public Dictionary<string, object> GetPlayedGames(string email)
        {
            return _gameRepository.GetPlayedGames(email);
        }

    }
}
