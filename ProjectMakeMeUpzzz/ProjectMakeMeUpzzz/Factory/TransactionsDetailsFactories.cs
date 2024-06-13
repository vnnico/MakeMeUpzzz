using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Factory
{
    public class TransactionsDetailsFactories
    {
        public static TransactionDetail CreateTransactionDetail(int transactionDetailId, int transactionId, int makeupId, int quantity)
        {
            return new TransactionDetail
            {
                TransactionDetailID = transactionDetailId,
                TransactionID = transactionId,
                MakeupID = makeupId,
                Quantity = quantity
            };
        }

        
        /*
        internal static TransactionDetail CreateTransactionDetail(int v, int transactionID, int makeupId, int quantity)
        {
            throw new NotImplementedException();
        } 
        */
    }
}