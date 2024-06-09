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
        int CreateGame(GameDTO newGame);

        [OperationContract]
        Dictionary<string, object> GetCategoriesList();

        [OperationContract]
        Dictionary<string, object> GetWordsList();

        [OperationContract]
        Dictionary<string, object> SetChallenger(string gameCode, string email);

        [OperationContract]
        Dictionary<string, object> SetGameStatus(string gameCode, string status);

        [OperationContract]
        Dictionary<string, object> GetWaitingGames();

        [OperationContract]
        Dictionary<string, object> GetPlayerType(string email, string gameCode);

        [OperationContract]
        Dictionary<string, object> GetLanguagesList();

    }
}
