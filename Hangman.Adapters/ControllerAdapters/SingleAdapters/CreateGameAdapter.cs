using Hangman.Adapters.ControllerAdapters.Services.Game;
using Hangman.Adapters.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hangman.Adapters.ControllerAdapters.SingleAdapters
{
    public class CreateGameAdapter
    {

        public GameDTO CreateGame(GameDTO newGame)
        {
            var service = new GameServicesClient(new System.ServiceModel.BasicHttpsBinding(), new System.ServiceModel.EndpointAddress(Constants.endPointGameServices));


            GameDTO response = service.CreateGameAsync(newGame).Result;

            switch (response.ResponseCode)
            {
                case 0:
                    Console.WriteLine("La partida se creó correctamente.");
                    break;
                case 1:
                    throw new Exception("No se encontró información de la entidad en la base de datos");
                case 2:
                    throw new Exception("Error en la consulta, verifique el error en el servidor");
                case 3:
                    throw new Exception("No se ha podido conectar con la base de datos. Por favor, intente más tarde");
                default:
                    throw new Exception("Se recibió un código de respuesta inesperado: " + response.ResponseCode);
            }

            return response;
        }

        public List<CategoryDTO> GetCategoriesList()
        {
            var service = new GameServicesClient(new System.ServiceModel.BasicHttpsBinding(), new System.ServiceModel.EndpointAddress(Constants.endPointGameServices));

            List<CategoryDTO> response = service.GetCategoriesListAsync().Result;

            foreach (var category in response)
            {
                if (category.ResponseCode == 1)
                {
                    throw new Exception();
                }

                if (category.ResponseCode == 2)
                {
                    throw new Exception("Error en la consulta, verifique el error en el servidor");
                }

                if (category.ResponseCode == 3)
                {
                    throw new Exception("No se ha podido conectar con la base de datos. Por favor, intente más tarde");
                }

                if (category.ResponseCode < 0 || category.ResponseCode > 3)
                {
                    throw new Exception("Error de conexión");
                }
            }

            return response;
        }

        public List<WordDTO> GetWordsList()
        {
            var service = new GameServicesClient(new System.ServiceModel.BasicHttpsBinding(), new System.ServiceModel.EndpointAddress(Constants.endPointGameServices));

            List<WordDTO> response = service.GetWordsListAsync().Result;

            WordDTO responseCode = response[0];

            switch(responseCode.ResponseCode)
            {
                case 1:
                    throw new Exception("No se encontró información de la entidad en la base de datos");
                case 2:
                    throw new Exception("Error en la consulta, verifique el error en el servidor");
                case 3:
                    throw new Exception("No se ha podido conectar con la base de datos. Por favor, intente más tarde");
                case 4:
                    throw new Exception("Error de conexión");
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
