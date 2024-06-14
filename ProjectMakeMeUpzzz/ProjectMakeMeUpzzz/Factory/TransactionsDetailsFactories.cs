using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Factory
{
    public class TransactionsDetailsFactories
    {
        public static TransactionDetail Create(int transactionDetailID, int  transactionId, int makeupId, int quantity)
        {
            return new TransactionDetail
            {
                TransactionDetailID = transactionDetailID,
                TransactionID = transactionId,
                MakeupID = makeupId,
                Quantity = quantity
            };
        }

    }
}