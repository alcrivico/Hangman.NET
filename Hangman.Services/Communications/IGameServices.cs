using Hangman.Services.Models.DTO;
using System.Collections.Generic;
using System.ServiceModel;

namespace Hangman.Services.Communications
{
    
    [ServiceContract]
    public interface IGameServices
    {
        
        [OperationContract]
        GameDTO CreateGame(GameDTO newGame);

        [OperationContract]
        List<CategoryDTO> GetCategoriesList();

        [OperationContract]
        List<WordDTO> GetWordsList();

        [OperationContract]
        GameDTO SetChallenger(string gameCode, string challengerEmail);

        [OperationContract]
        GameDTO SetGameStatus(string gameCode, string status);

        [OperationContract]
        List<GameDTO> GetWaitingGames();

        [OperationContract]
        GameDTO GetPlayerType(string email, string gameCode);

        [OperationContract]
        List<LanguageDTO> GetLanguagesList();

        [OperationContract]
        WordDTO SearchWord(string word);

    }
}
