using Hangman.Services.Models.POCO;
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
        Player LogIn(string email, string pass);//Cambiar el retorno

        [OperationContract]
        Player SignUp(Player player);//Cambiar el retorno
    }
}
