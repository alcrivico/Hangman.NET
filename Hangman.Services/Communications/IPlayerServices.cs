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
        //CAMBIAR RETORNOS A DICTIONARY
        [OperationContract]
        PlayerDTO LogIn(string email, string pass);//Cambiar el retorno

        [OperationContract]
        PlayerDTO SignUp(Player player);//Cambiar el retorno

        [OperationContract]
        PlayerDTO UpdateProfile(Player player);//Cambiar el retorno

        [OperationContract]
        List<GameDTO> GetPlayedGames(int idPlayer);//Cambiar el retorno


    }
}
