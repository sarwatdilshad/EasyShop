using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyShop.Models
{
    public class CartModel
    {
        public string InsertCart(Cart cart)
        {
            try
            {
                EasyShopDBEntities db = new EasyShopDBEntities();
                db.Carts.Add(cart);
                db.SaveChanges();

                return cart.DatePurchased + " succesfully inserted";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public string UpdateCart(int id, Cart cart)
        {
            try
            {
                EasyShopDBEntities db = new EasyShopDBEntities();

                //Fetch object from db
                Cart p = db.Carts.Find(id);

                p.DatePurchased = cart.DatePurchased;
                p.ClientID = cart.ClientID;
                p.Amount= cart.Amount;
                p.IsInCart= cart.IsInCart;
                p.ProductID = cart.ProductID;
                db.SaveChanges();
                return cart.DatePurchased + " succesfully updated";

            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public string DeleteCart(int id)
        {
            try
            {
                EasyShopDBEntities db = new EasyShopDBEntities();
                Cart cart = db.Carts.Find(id);

                db.Carts.Attach(cart);
                db.Carts.Remove(cart);
                db.SaveChanges();

                return cart.DatePurchased + " succesfully deleted";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public List<Cart> GetOrdersInCart(string clientId)
        {
            EasyShopDBEntities db = new EasyShopDBEntities();
            List<Cart> orders = (from x in db.Carts
                                 where x.ClientID == clientId
                                 && x.IsInCart
                                 orderby x.DatePurchased descending
                                 select x).ToList();
            return orders;
        }

        public int GetAmountOfOrders(string clientId)
        {
            try
            {
                EasyShopDBEntities db = new EasyShopDBEntities();
                int amount = (from x in db.Carts
                              where x.ClientID == clientId
                              && x.IsInCart
                              select x.Amount).Sum();

                return amount;
            }
            catch
            {
                return 0;
            }
        }

        public void UpdateQuantity(int id, int quantity)
        {
            EasyShopDBEntities db = new EasyShopDBEntities();
            Cart p = db.Carts.Find(id);
            p.Amount = quantity;

            db.SaveChanges();
        }

        public void MarkOrdersAsPaid(List<Cart> carts)
        {
            EasyShopDBEntities db = new EasyShopDBEntities();

            if (carts != null)
            {
                foreach (Cart cart in carts)
                {
                    Cart oldCart = db.Carts.Find(cart.ID);
                    oldCart.DatePurchased = DateTime.Now;
                    oldCart.IsInCart = false;
                }
                db.SaveChanges();
            }
        }
    }
}