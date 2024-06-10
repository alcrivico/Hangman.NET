using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangman.Services.Models.DTO;
using Hangman.Services.Models.POCO;

namespace Hangman.Services.Repositories.Interfaces
{
    public interface ILanguageRepository
    {
        List<LanguageDTO> GetLanguagesList();
    }
}
