using Hangman.Services.Models.DTO;
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

        Dictionary<string, object> SignUp(PlayerDTO playerDTO);

        Dictionary<string, object> UpdateProfile(PlayerDTO updatedPlayerDTO);

        //Dictionary<string, object> GetPlayerById(int playerId);

    }
}
