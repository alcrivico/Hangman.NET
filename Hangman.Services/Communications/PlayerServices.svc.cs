using Hangman.Services.Models.DTO;
using Hangman.Services.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Hangman.Services.Communications
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PlayerServices" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PlayerServices.svc o PlayerServices.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class PlayerServices : IPlayerServices
    {
        public Player LogIn (string email, string pass)
        {
            return (Player)PlayerDTO.LogIn(email, pass)["Player"];
        }
    }
}
