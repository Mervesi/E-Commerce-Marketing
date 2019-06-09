using OrnekE_Ticaret.DAL;
using OrnekE_Ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrnekE_Ticaret.Controllers
{
    public class ProductController : Controller
    {
        CategoryAccess categoryAccess = new CategoryAccess();
        ProductAccess productAccess = new ProductAccess();
        // GET: Product
        public ActionResult Index()
        {
            List<Category> categories = categoryAccess.GetProudctCategories();
            ViewBag.Categories = new SelectList(categories,"CategoryID","CategoryName");
            ViewBag.categoryList = categories;
            List<Product> products = productAccess.GetProudcts();
            return View(products);
        }
        
        public PartialViewResult ProductsByCategory(int? id)
        {
            List<Product> products = productAccess.GetProductsByCategoryId(id);//(int)id-->nullable degerı pars etme
            var category = categoryAccess.GetProductCategoryById(id);
            ViewBag.CategoryName = category.CategoryName;
            return PartialView(products);
        }
        //public PartialViewResult AddProductToChart(int? id)
        //{
        //    var product = productAccess.GetProductByID(id);

        //    return PartialView(product);
        //}
    }
}