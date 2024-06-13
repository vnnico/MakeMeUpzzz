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
            DatabaseEntities3 db = new DatabaseEntities3();
            return db.TransactionHeaders.ToList();
        }
    }
}