using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectMakeMeUpzzz.Models;

namespace ProjectMakeMeUpzzz.Repositories
{
    public class CartRepositories
    {
        private static DatabaseEntities3 db = new DatabaseEntities3();
        public static List<Cart> GetCartByUserId(int userId)
        {
            return db.Carts.Where(x => x.UserID == userId).ToList();
        }
        public static Cart GetCartById(int cartId)
        {
            return db.Carts.Find(cartId);
        }

        public static Cart GetLastCart()
        {
            return db.Carts.ToList().LastOrDefault();
        }

        public static Cart AddCart(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();
            return cart;
        }

        public static int RemoveAllCartByUserID(int userID)
        {
            List<Cart> carts = GetCartByUserId(userID);

            if (carts != null && carts.Count > 0)
            {

                foreach (Cart cart in carts)
                {
                    db.Carts.Remove(cart);
                    db.SaveChanges();
                }

                return 1;
            }

            return 0;

        }

    }
}