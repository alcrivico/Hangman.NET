using Hangman.Adapters.ControllerAdapters.Services.Player;
using Hangman.Adapters.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Hangman.Adapters.ControllerAdapters.SingleAdapters
{
    public class ProfileAdapter
    {

        public List<GameDTO> GetPlayedGames(string email)
        {
            var conexion = new PlayerServicesClient(new System.ServiceModel.BasicHttpsBinding(), new System.ServiceModel.EndpointAddress(Constants.endPointPlayerServices));


            List<GameDTO> response = conexion.GetPlayedGamesAsync(email).Result;

            foreach (var game in response)
            {

                if (game.ResponseCode == 2)
                {
                    throw new Exception("Error en la consulta, verifique el error en el servidor");
                }

                if (game.ResponseCode == 3)
                {
                    throw new Exception("No se ha podido conectar con la base de datos. Por favor, intente más tarde");
                }

                if (game.ResponseCode < 0 && game.ResponseCode > 3)
                {
                    throw new Exception("Error de conexión");
                }

            }

            return response;

        }

        

    }
}
