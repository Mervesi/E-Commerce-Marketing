using OrnekE_Ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrnekE_Ticaret.DAL
{
    public class CategoryAccess
    {
        ShoppingExampleDbEntities2 db;
        public List<Category> GetProudctCategories()
        {
            using (db=new ShoppingExampleDbEntities2())
            {
                return db.Category.ToList();
            }
        }
        public Category GetProductCategoryById(int? id)
        {
            using (db=new ShoppingExampleDbEntities2())
            {
                return db.Category.FirstOrDefault(m => m.CategoryID == id);
            }
        }
    }
}