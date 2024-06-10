using Hangman.Services.Models.DTO;
using System.Collections.Generic;

namespace Hangman.Services.Repositories.Interfaces
{
    public interface IGameRepository
    {

        GameDTO CreateGame(GameDTO newGame);

        List<GameDTO> GetPlayedGames(string email);

        List<GameDTO> GetWaitingGames();

        GameDTO SetGameStatus(string gameCode, string status);

        GameDTO SetChallenger(string gameCode, string challengerEmail);

        GameDTO GetPlayerType(string email, string gameCode);

    }
}
