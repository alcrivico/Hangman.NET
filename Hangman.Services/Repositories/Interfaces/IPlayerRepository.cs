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

        PlayerDTO LogIn(string email, string password);

        PlayerDTO SignUp(PlayerDTO playerDTO);

        PlayerDTO UpdateProfile(PlayerDTO updatedPlayerDTO);

        //Dictionary<string, object> GetPlayerById(int playerId);

    }
}
