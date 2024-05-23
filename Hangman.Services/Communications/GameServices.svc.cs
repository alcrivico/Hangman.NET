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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "GameServices" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione GameServices.svc o GameServices.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class GameServices : IGameServices
    {
        public string CreateGame(Game newGame)
        {
            return (string)GameDTO.CreateGame(newGame)["Message"];
        }

        public List<Category> GetCategoriesList()
        {
            return (List<Category>)CategoryDTO.GetCategoriesList()["Categories"]; 
        }

        public List<Word> GetWordsList()
        {
            return (List<Word>)WordDTO.GetWordsList()["Words"];
        }

        public string SetChallenger(int idGame, int idChallenger)
        {
            return (string)GameDTO.SetChallenger(idGame, idChallenger)["Message"];
        }

        public string SetGameStatus(int idGame, int idStatus)
        {
            return (string)GameDTO.SetGameStatus(idGame, idStatus)["Message"];
        }

        /*No jala, debo revisarlo xd
        public string GetPlayerType(int playerId, int gameId)
        {
            var response = GameDTO.GetPlayerType(playerId, gameId);
            return response.ContainsKey("PlayerType") ? response["PlayerType"].ToString() : "Unknown";
        }*/
    }
}
