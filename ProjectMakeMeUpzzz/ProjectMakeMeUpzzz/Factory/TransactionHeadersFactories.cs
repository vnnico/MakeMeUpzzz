using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Factory
{
    public class TransactionHeadersFactories
    {
        public static TransactionHeader Create(int transactionId, int userId, DateTime transactionDate, string status) 
        {

            return new TransactionHeader
            {
                TransactionID = transactionId,
                UserID = userId,
                TransactionDate = transactionDate,
                Status = status
            };
        }
    }
}