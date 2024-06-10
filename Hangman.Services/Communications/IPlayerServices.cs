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
        PlayerDTO LogIn(string email, string pass);

        [OperationContract]
        PlayerDTO SignUp(PlayerDTO player);

        [OperationContract]
        PlayerDTO UpdateProfile(PlayerDTO player);

        [OperationContract]
        List<GameDTO> GetPlayedGames(string email);


    }
}
