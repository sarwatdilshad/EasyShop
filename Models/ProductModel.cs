using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyShop.Models
{
    public class ProductModel
    {
        public string InsertProduct(Product product)
        {
            try
            {
                EasyShopDBEntities db = new EasyShopDBEntities();
                db.Products.Add(product);
                db.SaveChanges();

                return product.Name + " succesfully inserted";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public string UpdateProduct(int id, Product product)
        {
            try
            {
                EasyShopDBEntities db = new EasyShopDBEntities();

                //Fetch object from db
                Product p = db.Products.Find(id);

                p.Name = product.Name;
                p.Price = product.Price;
                p.TypeID = product.TypeID;
                p.Description = product.Description;
                p.Image = product.Image;

                db.SaveChanges();
                return product.Name + " succesfully updated";

            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public string DeleteProduct(int id)
        {
            try
            {
                EasyShopDBEntities db = new EasyShopDBEntities();
                Product product = db.Products.Find(id);

                db.Products.Attach(product);
                db.Products.Remove(product);
                db.SaveChanges();

                return product.Name + " succesfully deleted";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public Product GetProduct(int id)
        {
            try
            {
                using (EasyShopDBEntities db = new EasyShopDBEntities())
                {
                    //  Product product = db.Products.Find(id);
                    Product product = db.Products.Where(p => p.ID == id).FirstOrDefault();
                    return product;
                }

                //DBEasyShopEntities db = new DBEasyShopEntities();
                //Product product = db.Products.Where(p => p.ID == id).FirstOrDefault();
                //return product;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<Product> GetAllProducts()
        {
            try
            {
                using (EasyShopDBEntities db = new EasyShopDBEntities())
                {
                    List<Product> products = (from x in db.Products select x).ToList();
                    return products;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<Product> GetProductsByTypes(int typeId)
        {
            try
            {
                using (EasyShopDBEntities db = new EasyShopDBEntities())
                {
                    List<Product> products = (from x in db.Products
                                              where x.TypeID == typeId
                                              select x).ToList();
                    return products;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

    }

}