using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hangman.Services.Models.DTO
{
    public class CategoryDTO
    {

        public int CategoryId { get; set; }

        public string CategoryES { get; set; }

        public string CategoryEN { get; set; }

        public int ResponseCode { get; set; }
 
    }
}