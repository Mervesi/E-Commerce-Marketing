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
            PopulateCategoryList();
            List<Product> products = productAccess.GetProudcts();
            ViewBag.ProductList = products;
            return View();
        }
        public PartialViewResult GetAllProduct()
        {
            List<Product> products = productAccess.GetProudcts();
            ViewBag.ProductList = products;
            return PartialView();
        }
        public PartialViewResult ProductsByCategory(int? id)
        {
            List<Product> products = productAccess.GetProudcts();
            PopulateCategoryList();
            ViewBag.ProductList = products;
            return PartialView();
        }
        public ActionResult DeleteProduct(int? id)
        {
            var isDelete = productAccess.DeleteProductByID(id);
            if (isDelete)
            {
                return RedirectToAction("GetProduct", "Admin");
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
            PopulateCategoryList();
            return View();
        }

        private void PopulateCategoryList()
        {
            List<Category> categories = categoryAccess.GetProudctCategories();
            ViewBag.ProductCategoryID = new SelectList(categories, "CategoryID", "CategoryName");
            ViewBag.categoryList = categories;
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Guid.NewGuid().ToString().Replace("-", "");

                string uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
                string tamYol = "~/Content/Images/ProductPictures/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(tamYol));
                product.PicturePath = dosyaAdi + uzanti;
            }
            List<Product> productList = productAccess.GetProudcts();

            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Girdiğiniz bilgileri kontrol ediniz.";
                return View();
            }
            PopulateCategoryList();
            productList = productAccess.GetProudcts();
            var ısCreate = productAccess.CreateProduct(product);
            ViewBag.Message = "Kayıt Başarılı!";
            return RedirectToAction("GetProduct", productList);

        }

    }
}