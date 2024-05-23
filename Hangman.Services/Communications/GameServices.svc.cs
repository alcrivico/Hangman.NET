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
        //CAMBIAR RETORNOS A DICTIONARY
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

        public List<Game> GetWaitingGames()
        {
            return (List<Game>)GameDTO.GetWaitingGames()["Games"];
        }
        public string GetPlayerType(int playerId, int gameId)
        {
            return (string)GameDTO.GetPlayerType(playerId, gameId)["PlayerType"];
        }

        public Player GetPlayerById(int playerId)
        {
            return (Player)PlayerDTO.GetPlayerById(playerId)["Player"];
        }

        public List<Language> GetLanguages()
        {
            return (List<Language>)LanguageDTO.GetLanguages()["Languages"];
        }
    }
}
