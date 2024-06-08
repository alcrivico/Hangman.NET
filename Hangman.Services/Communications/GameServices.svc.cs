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

            Game game = Game.ConvertDTOToGame(newGame);

            Game gameAnswer = _gameRepository.CreateGame(game);

            return Game.ConvertGameToDTO(gameAnswer);

        }

        public List<CategoryDTO> GetCategoriesList()
        {

            List<Category> categories = _categoryRepository.GetCategoriesList();

            return Category.ConvertCategoryListToDTO(categories);

        }

        public List<WordDTO> GetWordsList()
        {

            List<Word> words = _wordRepository.GetWordsList();

            return Word.ConvertWordListToDTO(words);

        }

        public GameDTO SetChallenger(string gameCode, int idChallenger)
        {

            Game gameAnswer = _gameRepository.SetChallenger(gameCode, idChallenger);

            return Game.ConvertGameToDTO(gameAnswer);

        }

        public GameDTO SetGameStatus(string gameCode, int idStatus)
        {

            Game gameAnswer = _gameRepository.SetGameStatus(gameCode, idStatus);

            return Game.ConvertGameToDTO(gameAnswer);

        }

        public List<GameDTO> GetWaitingGames()
        {

            List<Game> games = _gameRepository.GetWaitingGames();

            return Game.ConvertGameListToDTO(games);

        }

        public string GetPlayerType(int playerId, string gameCode)
        {
            return _gameRepository.GetPlayerType(playerId, gameCode);
        }

        public List<LanguageDTO> GetLanguagesList()
        {

            List<Language> languages = _languageRepository.GetLanguagesList();

            return Language.ConvertLanguageListToDTO(languages);

        }

    }
}
