using Hangman.Services.Models.POCO;
using Hangman.Services.Models.DTO;
using Hangman.Services.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Hangman.Services.Communications
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IPlayerServices" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPlayerServices
    {

        [OperationContract]
        Dictionary<string, object> LogIn(string email, string pass);

        [OperationContract]
        Dictionary<string, object> SignUp(Player player);

        [OperationContract]
        Dictionary<string, object> UpdateProfile(Player player);

        [OperationContract]
        Dictionary<string, object> GetPlayedGames(int idPlayer);


    }
}
