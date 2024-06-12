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
            DatabaseEntities1 db = new DatabaseEntities1();
            return db.TransactionHeaders.ToList();
        }
    }
}