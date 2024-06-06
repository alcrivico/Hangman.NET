using Hangman.Services.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Services.Repositories.Interfaces
{
    public interface IPlayerRepository
    {

        Player LogIn(string email, string password);

        Player SignUp(Player newPlayer);

        Player UpdateProfile(Player updatedPlayer);

        Player GetPlayerById(int playerId);

    }
}
