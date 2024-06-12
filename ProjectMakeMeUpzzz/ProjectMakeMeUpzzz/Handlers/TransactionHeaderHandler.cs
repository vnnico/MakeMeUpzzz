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
    public class TransactionHeaderHandler
    {
        public static object TransactionDetailFactory { get; private set; }



        public static Response<List<TransactionHeader>> GetAllTransactionHeaders()
        {
            List<TransactionHeader> transactions = TransactionHeaderRepositories.GetAllTransactionHeaders();
            if (transactions.Count > 0)
            {
                return new Response<List<TransactionHeader>>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = transactions
                };
            }
            return new Response<List<TransactionHeader>>
            {
                Message = "No transaction found",
                IsSuccess = false,
                Payload = null
            };
        }

        public static Response<TransactionHeader> GetTransactionHeaderById(int id)
        {
            TransactionHeader transaction = TransactionHeaderRepositories.GetTransactionHeaderById(id);
            if (transaction != null)
            {
                return new Response<TransactionHeader>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = transaction
                };
            }
            return new Response<TransactionHeader>
            {
                Message = "No transaction found",
                IsSuccess = false,
                Payload = null
            };
        }

        public static Response<List<TransactionHeader>> GetTransactionHeaderByUserId(int id)
        {
            List<TransactionHeader> transactions = TransactionHeaderRepositories.GetTransactionHeaderByUserId(id);

            if (transactions != null)
            {
                return new Response<List<TransactionHeader>>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = transactions
                };
            }
            return new Response<List<TransactionHeader>>
            {
                Message = "Transaction not found",
                IsSuccess = false,
                Payload = null
            };

        }

        public static Response<TransactionHeader> UpdateTransactionHeaderStatus(TransactionHeader transaction)
        {
            TransactionHeader tran = TransactionHeaderRepositories.UpdateTransactionHeaderStatus(transaction);
            if (tran != null)
            {
                return new Response<TransactionHeader>
                {
                    Message = "Success",
                    IsSuccess = true,
                    Payload = tran
                };
            }
            return new Response<TransactionHeader>
            {
                Message = "Transaction not found",
                IsSuccess = false,
                Payload = null
            };
        }

        public static Response<TransactionHeader> CheckoutCart(List<Cart> carts)
        {
            TransactionHeader transactionHeader = TransactionHeadersFactories.CreateTransactionHeader(GenerateTransactionID(), carts[0].UserID, DateTime.Now, "unhandled");
            if (TransactionHeaderRepositories.InsertTransactionHeader(transactionHeader) == 0)
            {
                return new Response<TransactionHeader>
                {
                    Message = "Failed to checkout",
                    IsSuccess = false,
                    Payload = null
                };
            }

            foreach (Cart cart in carts)
            {
                Response<TransactionDetail> response = TransactionDetailHandler.InsertTransactionDetail(transactionHeader.TransactionID, cart.MakeupID, cart.Quantity);
                if (!response.IsSuccess)
                {
                    RemoveTransactionDetails(transactionHeader);
                    return new Response<TransactionHeader>
                    {
                        Message = "Failed to checkout",
                        IsSuccess = false,
                        Payload = null
                    };
                }
            }

            return new Response<TransactionHeader>
            {
                Message = "Success",
                IsSuccess = true,
                Payload = transactionHeader
            };
        }

        private static int GenerateTransactionID()
        {
            TransactionHeader transactionHeader = TransactionHeaderRepositories.GetLastTransactionHeader();
            if (transactionHeader == null)
            {
                return 1;
            }
            return transactionHeader.TransactionID + 1;
        }

        private static Response<TransactionHeader> RemoveTransactionDetails(TransactionHeader transactionHeader)
        {
            TransactionDetailHandler.DeleteTransactionDetails(transactionHeader.TransactionID);
            if (TransactionHeaderRepositories.DeleteTransactionHeader(transactionHeader.TransactionID) == 0)
            {
                return new Response<TransactionHeader>
                {
                    Message = "Failed to remove transaction details",
                    IsSuccess = false,
                    Payload = null
                };
            }
            return new Response<TransactionHeader>
            {
                Message = "Remove transaction details success",
                IsSuccess = true,
                Payload = null
            };
        }
    }
}