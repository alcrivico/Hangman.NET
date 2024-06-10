using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangman.Adapters.ControllerAdapters.Services.Player;

namespace Hangman.Adapters.ControllerAdapters.SingleAdapters
{
    public class LogInAdapter
    {
        public PlayerDTO LogIn(string username, string password)
        {
            var conexion = new PlayerServicesClient();

            PlayerDTO response = conexion.LogInAsync(username, password).Result;

            if (response.ResponseCode == 1)
            {
                throw new Exception("No se encontró información de la entidad en la base de datos");
            }

            if (response.ResponseCode == 2)
            {
                throw new Exception("Error en la consulta, verifique el error en el servidor");
            }

            if (response.ResponseCode == 3)
            {
                throw new Exception("No se ha podido conectar con la base de datos. Por favor, intente más tarde");
            }

            if (response.ResponseCode < 0 && response.ResponseCode > 3)
            {
                throw new Exception("Error de conexión");
            }

            return response;
        }
    }
}
