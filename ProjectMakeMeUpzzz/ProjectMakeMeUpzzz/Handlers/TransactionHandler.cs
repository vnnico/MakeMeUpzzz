using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;
using ProjectMakeMeUpzzz.Repositories;

namespace ProjectMakeMeUpzzz.Handlers
{
    public class TransactionHandler
    {

        
        public static List<TransactionHeader> GetTransactionHeaders()
        {
            return TransactionRepositories.GetTransactionHeaders();
        }
        

        
    }
}