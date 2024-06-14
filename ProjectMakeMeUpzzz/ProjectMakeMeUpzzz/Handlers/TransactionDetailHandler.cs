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
        public static Response<TransactionDetail> AddTransactionDetail(int transactionID, int makeupId, int quantity)
        {
            TransactionDetail transactionDetail = TransactionsDetailsFactories.Create(GenerateNewID(), transactionID, makeupId, quantity);
            if (TransactionDetailRepositories.addTransactionDetail(transactionDetail) == 0)
            {
                return new Response<TransactionDetail>
                {
                    Message = "Failed to add transaction detail",
                    IsSuccess = false,
                    Payload = null
                };
            }

            return new Response<TransactionDetail>
            {
                Message = "Transaction detail added successfully",
                IsSuccess = true,
                Payload = transactionDetail
            };
        }

        public static Response<List<TransactionDetail>> RetrieveTransactionDetailByTransactionId(int id)
        {
            List<TransactionDetail> transactionDetails = TransactionDetailRepositories.GetTransactionDetailByTransactionId(id);
            if (transactionDetails != null)
            {
                return new Response<List<TransactionDetail>>
                {
                    Message = "Transaction details retrieved successfully",
                    IsSuccess = true,
                    Payload = transactionDetails
                };
            }
            return new Response<List<TransactionDetail>>
            {
                Message = "No transaction details found",
                IsSuccess = false,
                Payload = null
            };
        }

        public static Response<TransactionDetail> RemoveTransactionDetails(int transactionId)
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
                Message = "Transaction details deleted successfully",
                IsSuccess = true,
                Payload = null
            };
        }

        private static int GenerateNewID()
        {
            TransactionDetail lastTransactionDetail = TransactionDetailRepositories.GetLastTransactionDetail();
            if (lastTransactionDetail == null)
            {
                return 1;
            }
            return lastTransactionDetail.TransactionDetailID + 1;
        }
    }
}
