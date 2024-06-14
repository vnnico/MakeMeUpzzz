using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Handlers;
using ProjectMakeMeUpzzz.Helpers;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Controllers
{
    public class TransactionDetailController
    {
        public static Response<List<TransactionDetail>> GetTransactionDetailByTransactionId(int id)
        {
            return TransactionDetailHandler.RetrieveTransactionDetailByTransactionId(id);
        }
    }
}