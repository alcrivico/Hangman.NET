using Hangman.Adapters.ControllerAdapters.Services.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hangman.Adapters.ControllerAdapters.SingleAdapters
{
    internal class CreateGameAdapter
    {
        public void CreateGame(GameDTO newGame)
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
        }

        public List<LanguageDTO> GetLanguagesList()
        {
            var service = new GameServicesClient();

            List<LanguageDTO> languages = service.GetLanguagesListAsync().Result;

            if (languages != null && languages.Count > 0)
            {
                return languages;
            }
            else
            {
                throw new Exception("No se pudieron obtener los idiomas del servicio.");
            }
        }
    }
}
