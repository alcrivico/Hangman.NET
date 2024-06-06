using Hangman.Services.Models.POCO; // Eliminar al cambiar todos los POCO por DTOs
using Hangman.Services.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

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
        GameDTO SetChallenger(string gameCode, int idChallenger);

        [OperationContract]
        GameDTO SetGameStatus(string gameCode, int idStatus);

        [OperationContract]
        List<GameDTO> GetWaitingGames();

        [OperationContract]
        string GetPlayerType(int playerId, string gameCode);

        [OperationContract]
        PlayerDTO GetPlayerById(int playerId);

        [OperationContract]
        List<LanguageDTO> GetLanguagesList();

    }
}
