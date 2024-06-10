using Hangman.Services.Models.DTO;
using Hangman.Services.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Services.Repositories.Interfaces
{
    public interface IWordRepository
    {
        List<WordDTO> GetWordsList();

        WordDTO SearchWord(string word);

    }
}
