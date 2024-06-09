using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;

namespace Hangman.Services.Utilities
{
    public partial class YourDataContext : DataContext
    {
        public YourDataContext(string connectionString) : base(connectionString) { }

        [Function(Name = "dbo.AddGame")]
        public int AddGame([Parameter(Name = "CreatorID", DbType = "int")] int creatorID,
                            [Parameter(Name = "Id", DbType = "int")] int wordID,
                            [Parameter(Name = "Id", DbType = "int")] int languageID)
        {
            var result = ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), creatorID, wordID, languageID);
            return (int)result.ReturnValue;
        }
    }
}