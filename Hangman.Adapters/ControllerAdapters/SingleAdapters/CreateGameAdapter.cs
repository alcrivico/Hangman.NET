using Hangman.Adapters.ControllerAdapters.Services.Game;
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
            var service = new GameServicesClient();

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

        public List<LanguageDTO> GetLanguagesList()
        {
            var service = new GameServicesClient();

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
