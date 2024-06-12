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
        public static Response<List<TransactionDetail>> GetTransactionDetailById(int id)
        {
            return TransactionDetailHandler.GetTransactionDetailById(id);
        }
    }
}