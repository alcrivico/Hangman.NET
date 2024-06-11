using Hangman.Adapters.ControllerAdapters.Services.Game;
using Hangman.Adapters.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Adapters.ControllerAdapters.SingleAdapters
{
    public class GameAdapter
    {
        public void LeftGame(string gameCode)
        {

            var service = new GameServicesClient(new System.ServiceModel.BasicHttpsBinding(), new System.ServiceModel.EndpointAddress(Constants.endPointGameServices));

            GameDTO response = service.SetGameStatusAsync(gameCode, "Left").Result;

            switch (response.ResponseCode)
            {

                case 1:
                    throw new Exception("No se encontró información de la entidad en la base de datos");
                case 2:
                    throw new Exception("Error en la consulta, verifique el error en el servidor");
                case 3:
                    throw new Exception("No se ha podido conectar con la base de datos. Por favor, intente más tarde");

            }

        }

        public void SetChallenger(string gameCode, string challengerEmail)
        {

            var service = new GameServicesClient(new System.ServiceModel.BasicHttpsBinding(), new System.ServiceModel.EndpointAddress(Constants.endPointGameServices));

            GameDTO response = service.SetChallengerAsync(gameCode, challengerEmail).Result;

            switch (response.ResponseCode)
            {

                case 1:
                    throw new Exception("No se encontró información de la entidad en la base de datos");
                case 2:
                    throw new Exception("Error en la consulta, verifique el error en el servidor");
                case 3:
                    throw new Exception("No se ha podido conectar con la base de datos. Por favor, intente más tarde");

            }

        }

        public void SetGameStatus(string gameCode, string status)
        {
            var service = new GameServicesClient(new System.ServiceModel.BasicHttpsBinding(), new System.ServiceModel.EndpointAddress(Constants.endPointGameServices));

            GameDTO response = service.SetGameStatusAsync(gameCode, status).Result;

            switch (response.ResponseCode)
            {

                case 1:
                    throw new Exception("No se encontró información de la entidad en la base de datos");
                case 2:
                    throw new Exception("Error en la consulta, verifique el error en el servidor");
                case 3:
                    throw new Exception("No se ha podido conectar con la base de datos. Por favor, intente más tarde");

            }

        }

        public WordDTO SearchWord(string word)
        {
            var service = new GameServicesClient(new System.ServiceModel.BasicHttpsBinding(), new System.ServiceModel.EndpointAddress(Constants.endPointGameServices));

            WordDTO response = service.SearchWordAsync(word).Result;

            switch (response.ResponseCode)
            {

                case 1:
                    throw new Exception("No se encontró información de la entidad en la base de datos");
                case 2:
                    throw new Exception("Error en la consulta, verifique el error en el servidor");
                case 3:
                    throw new Exception("No se ha podido conectar con la base de datos. Por favor, intente más tarde");

            }

            return response;
        }

    }
}
