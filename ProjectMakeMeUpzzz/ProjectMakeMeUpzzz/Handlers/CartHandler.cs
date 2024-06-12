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
    public class CartHandler
    {
        public static int GenerateId()
        {
            Cart cart = CartRepositories.GetLastCart();
            if (cart == null)
            {
                return 1;
            }
            return cart.CartID + 1;
        }

        public static Response<List<Cart>> RemoveCartsById(List<int> cartIds)
        {
            string errorMessage = "Failed to remove cart: ";
            foreach (int cartId in cartIds)
            {
                if (CartRepositories.RemoveCartById(cartId) == 0)
                {
                    errorMessage += cartId + ", ";
                }
            }
            if (errorMessage != "Failed to remove cart: ")
            {
                return new Response<List<Cart>>
                {
                    IsSuccess = false,
                    Message = errorMessage.Substring(0, errorMessage.Length - 2),
                    Payload = null
                };
            }
            return new Response<List<Cart>>
            {
                IsSuccess = true,
                Message = "All Carts removed",
                Payload = null
            };
        }

        public static Response<Cart> InsertCart(int UserId, int MakeupId, int Quantity)
        {
            Cart cart = CartsFactories.CreateCart(GenerateId(), UserId, MakeupId, Quantity);
            if (CartRepositories.InsertCart(cart) == 0)
            {
                return new Response<Cart>
                {
                    IsSuccess = false,
                    Message = "Failed to insert cart",
                    Payload = null
                };
            }
            return new Response<Cart>
            {
                IsSuccess = true,
                Message = "Cart inserted",
                Payload = cart
            };
        }
        public static Response<Cart> GetCartById(int CardId)
        {
            Cart cart = CartRepositories.GetCartById(CardId);
            if (cart == null)
            {
                return new Response<Cart>
                {
                    IsSuccess = false,
                    Message = "Cart not found",
                    Payload = null
                };
            }
            return new Response<Cart>
            {
                IsSuccess = true,
                Message = "Cart found",
                Payload = cart
            };
        }

        public static Response<List<Cart>> GetCartByUserId(int UserId)
        {
            List<Cart> carts = CartRepositories.GetCartByUserId(UserId);
            if (carts.Count == 0)
            {
                return new Response<List<Cart>>
                {
                    IsSuccess = false,
                    Message = "Cart not found",
                    Payload = null
                };
            }
            return new Response<List<Cart>>
            {
                IsSuccess = true,
                Message = "Cart found",
                Payload = carts
            };
        }
    }
}