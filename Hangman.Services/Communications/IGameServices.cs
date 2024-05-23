using Hangman.Services.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Hangman.Services.Communications
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IGameServices" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IGameServices
    {
        //CAMBIAR RETORNOS A DICTIONARY
        [OperationContract]
        string CreateGame(Game newGame);

        [OperationContract]
        List<Category> GetCategoriesList();

        [OperationContract]
        List<Word> GetWordsList();

        [OperationContract]
        string SetChallenger(int idGame, int idChallenger);

        [OperationContract]
        string SetGameStatus(int idGame, int idStatus);

        [OperationContract]
        List<Game> GetWaitingGames();

        [OperationContract]
        string GetPlayerType(int playerId, int gameId);

        [OperationContract]
        Player GetPlayerById(int playerId);

        [OperationContract]
        List<Language> GetLanguages();
    }
}
