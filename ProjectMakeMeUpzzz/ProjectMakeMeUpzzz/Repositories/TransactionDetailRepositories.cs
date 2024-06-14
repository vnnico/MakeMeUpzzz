using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;


namespace ProjectMakeMeUpzzz.Repositories
{
    public class TransactionDetailRepositories
    {
        private static readonly DatabaseEntities3 db = new DatabaseEntities3();

        public static int InsertTransactionDetail(TransactionDetail transactionDetail)
        {
            db.TransactionDetails.Add(transactionDetail);
            return db.SaveChanges();
        }

        public static List<TransactionDetail> GetTransactionDetailByTransactionId(int transactionId)
        {
            return db.TransactionDetails.Where(td => td.TransactionID == transactionId).ToList();

        }

        public static List<TransactionDetail> GetTransactionDetailById(int transactionId)
        {
            return db.TransactionDetails.Where(x => x.TransactionID == transactionId).ToList();
        }

        public static TransactionDetail GetLastTransactionDetail()
        {
            return db.TransactionDetails.ToList().LastOrDefault();
        }

        public static TransactionDetail UpdateTransactionDetail(TransactionDetail transactionDetail)
        {
            TransactionDetail updatedTransactionDetail = db.TransactionDetails.Find(transactionDetail.TransactionID);
            updatedTransactionDetail.TransactionID = transactionDetail.TransactionID;
            updatedTransactionDetail.MakeupID = transactionDetail.MakeupID;
            updatedTransactionDetail.Quantity = transactionDetail.Quantity;
            db.SaveChanges();
            return transactionDetail;
        }

        public static int DeleteTransactionDetails(int transactionId)
        {
            List<TransactionDetail> transactionDetails = db.TransactionDetails.Where(x => x.TransactionID == transactionId).ToList();
            foreach (TransactionDetail transactionDetail in transactionDetails)
            {
                db.TransactionDetails.Remove(transactionDetail);
            }
            return db.SaveChanges();
        }
    }
}