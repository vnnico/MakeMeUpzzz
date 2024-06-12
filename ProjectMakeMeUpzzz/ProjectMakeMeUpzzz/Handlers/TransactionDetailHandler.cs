using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Factory;
using ProjectMakeMeUpzzz.Helpers;
using ProjectMakeMeUpzzz.Models;
using ProjectMakeMeUpzzz.Repositories;

namespace ProjectMakeMeUpzzz.Handlers
{
    public class TransactionDetailHandler
    {
        public static Response<TransactionDetail> InsertTransactionDetail(int transactionID, int makeupId, int quantity)
        {
            TransactionDetail transactionDetail = TransactionsDetailsFactories.CreateTransactionDetail(GenerateID(), transactionID, makeupId, quantity);
            if (TransactionDetailRepositories.InsertTransactionDetail(transactionDetail) == 0)
            {
                return new Response<TransactionDetail>
                {
                    Message = "Failed to insert transaction detail",
                    IsSuccess = false,
                    Payload = null
                };
            }

            return new Response<TransactionDetail>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = transactionDetail
            };
        }

        public static Response<List<TransactionDetail>> GetTransactionDetailById(int id)
        {
            List<TransactionDetail> transactionDetail = TransactionDetailRepositories.GetTransactionDetailByTransactionId(id);
            if (transactionDetail != null)
            {
                return new Response<List<TransactionDetail>>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = transactionDetail
                };
            }
            return new Response<List<TransactionDetail>>
            {
                Message = "no transaction detail",
                IsSuccess = false,
                Payload = null
            };
        }

        public static Response<TransactionDetail> DeleteTransactionDetails(int transactionId)
        {
            if (TransactionDetailRepositories.DeleteTransactionDetails(transactionId) == 0)
            {
                return new Response<TransactionDetail>
                {
                    Message = "Failed to delete transaction details",
                    IsSuccess = false,
                    Payload = null
                };
            }

            return new Response<TransactionDetail>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = null
            };
        }

        private static int GenerateID()
        {
            TransactionDetail lastTransactionDetail = TransactionDetailRepositories.GetLastTransactionDetail();
            if (lastTransactionDetail == null)
            {
                return 1;
            }
            return lastTransactionDetail.TransactionDetailID + 1;
        }

        internal static Response<TransactionDetail> InsertTransactionDetail(int transactionID, int makeupID, int? quantity)
        {
            throw new NotImplementedException();
        }
    }
}