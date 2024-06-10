using Hangman.Services.Models.DTO;
using Hangman.Services.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Hangman.Services.Repositories.Interfaces;
using Hangman.Services.Repositories.Implementations;

namespace Hangman.Services.Communications
{
    
    public class GameServices : IGameServices
    {

        private IWordRepository _wordRepository;
        private IPlayerRepository _playerRepository;
        private ILanguageRepository _languageRepository;
        private ICategoryRepository _categoryRepository;
        private IGameRepository _gameRepository;

        public GameServices(
            IWordRepository wordRepository, 
            IPlayerRepository playerRepository,
            ILanguageRepository languageRepository,
            ICategoryRepository categoryRepository,
            IGameRepository gameRepository)
        {

            _wordRepository = wordRepository;
            _playerRepository = playerRepository;
            _languageRepository = languageRepository;
            _categoryRepository = categoryRepository;
            _gameRepository = gameRepository;

        }

        public GameServices()
        {
            _wordRepository = new WordRepository();
            _playerRepository = new PlayerRepository();
            _languageRepository = new LanguageRepository();
            _categoryRepository = new CategoryRepository();
            _gameRepository = new GameRepository();
        }

        public GameDTO CreateGame(GameDTO newGame)
        {
            return _gameRepository.CreateGame(newGame);
        }

        public List<CategoryDTO> GetCategoriesList()
        {
            return _categoryRepository.GetCategoriesList();
        }

        public List<WordDTO> GetWordsList()
        {
            return _wordRepository.GetWordsList();
        }

        public GameDTO SetChallenger(string gameCode, string email)
        {
            return _gameRepository.SetChallenger(gameCode, email);
        }

        public GameDTO SetGameStatus(string gameCode, string status)
        {
            return _gameRepository.SetGameStatus(gameCode, status);
        }

        public List<GameDTO> GetWaitingGames()
        {
            return _gameRepository.GetWaitingGames();
        }

        public GameDTO GetPlayerType(string email, string gameCode)
        {
            return _gameRepository.GetPlayerType(email, gameCode);
        }

        public List<LanguageDTO> GetLanguagesList()
        {
            return _languageRepository.GetLanguagesList();
        }

        public WordDTO SearchWord(string word)
        {
            return _wordRepository.SearchWord(word);
        }

    }
}
