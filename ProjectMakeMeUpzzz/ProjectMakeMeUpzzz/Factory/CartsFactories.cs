using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Factory
{
    public class CartsFactories
    {
        public static Cart CreateCart(int cartId, int userId, int makeupId, int quantity)
        {
            return new Cart
            {
                CartID = cartId,
                UserID = userId,
                MakeupID = makeupId,
                Quantity = quantity
            };
        }
    }
}