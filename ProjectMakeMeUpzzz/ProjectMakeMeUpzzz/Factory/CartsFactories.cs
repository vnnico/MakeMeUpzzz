using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Factory
{
    public class CartsFactories
    {
        public static Cart CreateCart(int CardId, int UserId, int MakeupId, int Quantity)
        {
            return new Cart
            {
                CartID = CardId,
                UserID = UserId,
                MakeupID = MakeupId,
                Quantity = Quantity
            };
        }
    }
}