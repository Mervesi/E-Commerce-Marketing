using OrnekE_Ticaret.DAL;
using OrnekE_Ticaret.Models;
using OrnekE_Ticaret.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrnekE_Ticaret.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        ProductAccess productAccess = new ProductAccess();
        CategoryAccess categoryAccess = new CategoryAccess();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetProduct()
        {
            List<Category> categories = categoryAccess.GetProudctCategories();
            ViewBag.Categories = new SelectList(categories, "CategoryID", "CategoryName");
            ViewBag.categoryList = categories;
            List<Product> products = productAccess.GetProudcts();
            ViewBag.ProductList = products;
            return View();
        }
        public PartialViewResult ProductsByCategory(int? id)
        {
            List<Product> products = productAccess.GetProductsByCategoryId(id);//(int)id-->nullable degerı pars etme
            var category = categoryAccess.GetProductCategoryById(id);
            ViewBag.CategoryName = category.CategoryName;
            ViewBag.ProductList = products;
            return PartialView();
        }
        public ActionResult DeleteProduct(int? id)
        {
            var isDelete=productAccess.DeleteProductByID(id);
            if (isDelete)
            {
                return RedirectToAction("GetProduct","Admin");
            }
            else
            {
                return View();
            }
            
        }
        public ActionResult UpdateProduct(int? id)
        {
            return View();
        }
        public ActionResult CreateProduct()
        {
            List<Category> categories = categoryAccess.GetProudctCategories();
            ViewBag.Categories = new SelectList(categories, "CategoryID", "CategoryName");
            ViewBag.categoryList = categories;
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product,int? id)
        {
            //if (file != null)
            //{
            //    string pictureName = System.IO.Path.GetFileNameWithoutExtension(product.);
            //    string adres = Server.MapPath("~/Images/" + pictureName);
            //    file.SaveAs(adres);

            //    product.ProductPicture = Request.Form["ProdutPicture"];
            //    product.
            //}
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.Message = "Girdiğiniz bilgileri kontrol ediniz.";
            //    return View();
            //}
            //var ısCreate = productAccess.CreateProduct(product);
            //if (ısCreate)
            //{
            //    ViewBag.Message = "Kayıt Başarılı!";
            //    return View("Index");
            //}
            //else
            //{
                return View();
            
            
        }

    }
}