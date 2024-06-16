using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangman.Adapters.ControllerAdapters.Services.Game;
using Hangman.Adapters.Utilities;

namespace Hangman.Adapters.ControllerAdapters.SingleAdapters
{

    public class SearchGameAdapter
    {

        public List<GameDTO> GetWaitingGames() 
        {
            var service = new GameServicesClient(new System.ServiceModel.BasicHttpsBinding(), new System.ServiceModel.EndpointAddress(Constants.endPointGameServices));

            List<GameDTO> response = service.GetWaitingGamesAsync().Result;

            foreach (var game in response)
            {

                if (game.ResponseCode == 1)
                {
                    throw new Exception("No se encontró información de la entidad en la base de datos");
                }

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

            foreach (var game in response)
            {

                TimeSpan waitingTime = DateTime.Now - game.CreationDate;

                int minutes = (int) waitingTime.TotalMinutes;

                game.WaitingTime = (DateTime.Now - game.CreationDate).Minutes;

            }

            return response;

        }

        public List<LanguageDTO> GetLanguagesList()
        {

            var service = new GameServicesClient(new System.ServiceModel.BasicHttpsBinding(), new System.ServiceModel.EndpointAddress(Constants.endPointGameServices));

            List<LanguageDTO> response = service.GetLanguagesListAsync().Result;

            foreach (var language in response)
            {

                if (language.ResponseCode == 1)
                {
                    throw new Exception("No se encontró información de la entidad en la base de datos");
                }

                if (language.ResponseCode == 2)
                {
                    throw new Exception("Error en la consulta, verifique el error en el servidor");
                }

                if (language.ResponseCode == 3)
                {
                    throw new Exception("No se ha podido conectar con la base de datos. Por favor, intente más tarde");
                }

                if (language.ResponseCode < 0 && language.ResponseCode > 3)
                {
                    throw new Exception("Error de conexión");
                }

            }

            return response;

        }
        
    }

}
