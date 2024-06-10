using System;
using Hangman.Adapters.ControllerAdapters.Services.Player;

namespace Hangman.Adapters.ControllerAdapters.SingleAdapters
{
    public class SignUpAdapter
    {
        public PlayerDTO SignUp(PlayerDTO playerDTO)
        {
            var conexion = new PlayerServicesClient();

            PlayerDTO response = conexion.SignUpAsync(playerDTO).Result;

            if (response.ResponseCode == 1)
            {
                throw new Exception("Este correo no está disponible");
            }

            if (response.ResponseCode == 2)
            {
                throw new Exception("Error en la consulta, verifique el error en el servidor");
            }

            if (response.ResponseCode == 3)
            {
                throw new Exception("No se ha podido conectar con la base de datos. Por favor, intente más tarde");
            }

            if (response.ResponseCode < 0 || response.ResponseCode > 3)
            {
                throw new Exception("Error de conexión");
            }

            return response;
        }
    }
}