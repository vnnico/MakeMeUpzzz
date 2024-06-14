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
 

        public static Response<Cart> RemoveAllCartByUserID(int userId)
        {
            int result = CartRepositories.RemoveAllCartByUserID(userId);

            if (result > 0)
            {
                return new Response<Cart>
                {
                    IsSuccess = true,
                    Message = "All cart items removed successfully.",
                    Payload = null
                };
            }
            else
            {
                return new Response<Cart>
                {
                    IsSuccess = false,
                    Message = "No cart items found for the user",
                    Payload = null
                };
            }
        }
        public static Response<Cart> AddCart(int UserId, int MakeupId, int Quantity)
        {
            Cart lastCart = CartRepositories.GetLastCart();
            int id = Convert.ToInt32(lastCart.CartID);
            if (lastCart == null)
            {
                id = 1;
            } else {
                id += 1;
             };

            Cart cart = CartsFactories.Create(id, UserId, MakeupId, Quantity);
            if (CartRepositories.AddCart(cart) == null)
            {
                return new Response<Cart>
                {
                    IsSuccess = false,
                    Message = "Failed to Add Cart",
                    Payload = null
                };
            }
            return new Response<Cart>
            {
                IsSuccess = true,
                Message = "Cart Added Succesfully!",
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
                    Message = "No cart found",
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

            if (carts == null)
            {
                return new Response<List<Cart>>
                {
                    IsSuccess = false,
                    Message = "No carts found",
                    Payload = null
                };
            }
            return new Response<List<Cart>>
            {
                IsSuccess = true,
                Message = "All carts found",
                Payload = carts
            };
        }

  
    }
}