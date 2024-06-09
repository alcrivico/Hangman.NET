using Hangman.Services.Models.DTO;
using System.Collections.Generic;

namespace Hangman.Services.Repositories.Interfaces
{
    public interface IGameRepository
    {

        Dictionary<string, object> CreateGame(GameDTO newGame);

        Dictionary<string, object> GetPlayedGames(string name);

        Dictionary<string, object> GetWaitingGames();

        Dictionary<string, object> SetGameStatus(string gameCode, string status);

        Dictionary<string, object> SetChallenger(string gameCode, string challengerName);

        Dictionary<string, object> GetPlayerType(string name, string gameCode);

    }
}
