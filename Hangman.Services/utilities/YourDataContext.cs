using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Hangman.Services.Utilities
{
    public partial class YourDataContext : DataContext
    {
        public YourDataContext(string connectionString) : base(connectionString) { }

        [Function(Name = "dbo.AddGame")]
        public int AddGame([Parameter(Name = "CreatorID", DbType = "int")] int creatorID,
                            [Parameter(Name = "WordId", DbType = "int")] int wordID,
                            [Parameter(Name = "LanguageId", DbType = "int")] int languageID)
        {
            var result = ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), creatorID, wordID, languageID);
            return (int)result.ReturnValue;
        }
    }
}