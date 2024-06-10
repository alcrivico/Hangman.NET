using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangman.Adapters.ControllerAdapters.Services.Game;

namespace Hangman.Adapters.ControllerAdapters.SingleAdapters
{

    public class SearchGameAdapter
    {

        public List<GameDTO> GetWaitingGames() 
        {
            var conexion = new GameServicesClient();

            Dictionary<string, Object> response = conexion.GetWaitingGamesAsync().Result;

            switch ((int) response["ResponseCode"])
            {

                case 0:
                    return response["Data"] as List<GameDTO>;
                case 1:
                    throw new Exception("No se encontró información de la entidad en la base de datos");
                case 2:
                    throw new Exception("Error en la consulta, verifique el error en el servidor");
                case 3:
                    throw new Exception("No se ha podido conectar con la base de datos. Por favor, intente más tarde");
                default:
                    throw new Exception("Error de conexión");

            }


        }

        public List<LanguagesDTO> GetLanguagesList()
        {

           var conexion = new GameServicesClient();

            Dictionary<string, Object> response = conexion.GetLanguagesListAsync().Result;

            switch ((int) response["ResponseCode"])
            {

                case 0:
                    return response["Data"] as List<LanguagesDTO>;
                case 1:
                    throw new Exception("No se encontró información de la entidad en la base de datos");
                case 2:
                    throw new Exception("Error en la consulta, verifique el error en el servidor");
                case 3:
                    throw new Exception("No se ha podido conectar con la base de datos. Por favor, intente más tarde");
                default:
                    throw new Exception("Error de conexión");

            }

        }

    }

}
