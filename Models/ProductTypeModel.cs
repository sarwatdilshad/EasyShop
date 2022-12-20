using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyShop.Models
{
    public class ProductTypeModel
    {
        public string InsertProductTypeType(ProductType productType)
        {
            try
            {
                EasyShopDBEntities db = new EasyShopDBEntities();
                db.ProductTypes.Add(productType);
                db.SaveChanges();

                return productType.Name + " succesfully inserted";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public string UpdateProductType(int id, ProductType productType)
        {
            try
            {
                EasyShopDBEntities db = new EasyShopDBEntities();

                //Fetch object from db
                ProductType p = db.ProductTypes.Find(id);

                p.Name = productType.Name;
               

                db.SaveChanges();
                return productType.Name + " succesfully updated";

            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }

        public string DeleteProductType(int id)
        {
            try
            {
                EasyShopDBEntities db = new EasyShopDBEntities();
                ProductType productType = db.ProductTypes.Find(id);

                db.ProductTypes.Attach(productType);
                db.ProductTypes.Remove(productType);
                db.SaveChanges();

                return productType.Name + " succesfully deleted";
            }
            catch (Exception e)
            {
                return "Error:" + e;
            }
        }
    }
}