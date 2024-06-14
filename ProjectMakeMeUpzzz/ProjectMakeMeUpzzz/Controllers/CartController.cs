using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Handlers;
using ProjectMakeMeUpzzz.Helpers;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Controllers
{
    public class CartController
    {


        private static Response<T> CreateErrorResponse<T>(List<String> ErrorList)
        {
            String errorMessage = String.Join(" | ", ErrorList);
            return new Response<T>
            {
                Message = errorMessage,
                IsSuccess = false,
                Payload = default,
            };
        }

        private static int ValidateUserId(int userId, List<String> ErrorList)
        {
            if (userId > 0)
            {
                return userId;
            }
            ErrorList.Add("User ID cannot be empty");
            return 0;
        }

        private static int ValidateCartId(int cartId, List<String> ErrorList)
        {
            if (cartId > 0)
            {
                return cartId;
            }

            ErrorList.Add("CartID cannot be empty");
            return 0;
        }

        private static int ValidateMakeupId(int makeupId, List<String> ErrorList)
        {
            if (makeupId > 0)
            {
                return makeupId;
            }
            ErrorList.Add("MakeupID cannot be empty");
            return 0;
        }

        private static int ValidateQuantity(int quantity, List<String> ErrorList)
        {
            if (quantity > 0)
            {
                return quantity;
            }
            ErrorList.Add("Quantity must be greater than 0");
            return 0;
        }


  
        public static Response<Cart> RemoveAllCartsByUserID(int userID)
        {
            return CartHandler.RemoveAllCartByUserID(userID);
        }

        public static Response<Cart> GetCartById(int cartId)
        {
            List<String> ErrorList = new List<String>();
            int validatedCartId = ValidateCartId(cartId, ErrorList);

            if (ErrorList.Any())
            {
                return CreateErrorResponse<Cart>(ErrorList);
            }
            return CartHandler.GetCartById(validatedCartId);
        }
        public static Response<Cart> InsertCart(int userId, int makeupId, int quantity)
        {
            List<String> errors = new List<String>();
            int validatedUserId = ValidateUserId(userId, errors);
            int validatedMakeupId = ValidateMakeupId(makeupId, errors);
            int validatedQuantity = ValidateQuantity(quantity, errors);

            if (errors.Any())
            {
                return CreateErrorResponse<Cart>(errors);
            }

            return CartHandler.AddCart(validatedUserId, validatedMakeupId, validatedQuantity);
        }


        public static Response<List<Cart>> GetCartsByUserId(int userId)
        {
            List<String> errors = new List<String>();
            int validatedUserId = ValidateUserId(userId, errors);
            if (errors.Any())
            {
                return CreateErrorResponse<List<Cart>>(errors);
            }
            return CartHandler.GetCartByUserId(validatedUserId);
        }

    }
}