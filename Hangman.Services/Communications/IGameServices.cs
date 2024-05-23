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
        [OperationContract]
        Game CreateGame(Game newGame);

        [OperationContract]
        List<Category> GetCategoriesList();

        [OperationContract]
        List<Word> GetWordsList();

        [OperationContract]
        Game SetChallenger(int idGame, int idChallenger);

        [OperationContract]
        Game SetGameStatus(int idGame, int idStatus); 
    }
}
