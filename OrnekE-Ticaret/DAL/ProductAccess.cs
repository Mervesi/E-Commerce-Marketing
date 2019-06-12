using OrnekE_Ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

namespace OrnekE_Ticaret.DAL
{
    public class ProductAccess
    {
        ShoppingExampleDbEntities2 db;
        public List<Product> GetProudcts()
        {
            using (db = new ShoppingExampleDbEntities2())
            {
                return db.Product.Include(m => m.Category).ToList();
            }
        }
        public List<Product> GetProductsByCategoryId(int? id)
        {
            using (db = new ShoppingExampleDbEntities2())
            {
                var products = db.Product.Include(m => m.Category).Where(m => m.ProductCategoryID == id).ToList();
                return products;


            }
        }
        internal Product GetProductByID(int id)
        {
            using (db = new ShoppingExampleDbEntities2())
            {
                return db.Product.Find(id);
            }
        }
        //public List<Product> GetProductByID(int? id)
        //{
        //    using (db=new ShoppingExampleDbEntities())
        //    {
        //        var product = db.Product.Include(m=>m.Category).Where(m => m.ProductID == id).ToList();
        //        return product;
        //    }
        //}
        public bool DeleteProductByID(int? id)
        {
            using (db = new ShoppingExampleDbEntities2())
            {
                var product = db.Product.FirstOrDefault(m => m.ProductID == id);
                db.Product.Remove(product);
                var save = db.SaveChanges();
                if (save > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        public bool UpdateProduct(int? id)
        {
            return true;
        }
        public bool CreateProduct(Product product)
        {
            using (db = new ShoppingExampleDbEntities2())
            {
                db.Product.Add(product);
                var save = db.SaveChanges();
                if (save > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}