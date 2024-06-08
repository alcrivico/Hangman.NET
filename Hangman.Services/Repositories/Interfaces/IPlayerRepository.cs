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

        Dictionary<string, object> LogIn(string email, string password);

        Dictionary<string, object> SignUp(Player newPlayer);

        Dictionary<string, object> UpdateProfile(Player updatedPlayer);

        Dictionary<string, object> GetPlayerById(int playerId);

    }
}
