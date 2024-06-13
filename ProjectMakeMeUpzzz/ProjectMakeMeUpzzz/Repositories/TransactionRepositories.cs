using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Repositories
{
    public class TransactionRepositories
    {
        public static List<TransactionHeader> GetTransactionHeaders()
        {
            DatabaseEntities2 db = new DatabaseEntities2();
            return db.TransactionHeaders.ToList();
        }
    }
}