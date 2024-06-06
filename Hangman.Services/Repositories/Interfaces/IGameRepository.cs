using Hangman.Services.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Services.Repositories.Interfaces
{
    public interface IGameRepository
    {

        Game CreateGame(Game newGame);

        List<Game> GetPlayedGames(int idPlayer);

        List<Game> GetWaitingGames();

        Game SetGameStatus(string gameCode, int StatusID);

        Game SetChallenger(string gameCode, int idChallenger);

        String GetPlayerType(int playerId, string gameCode);

    }
}
