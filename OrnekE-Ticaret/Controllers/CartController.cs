using OrnekE_Ticaret.DAL;
using OrnekE_Ticaret.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrnekE_Ticaret.Controllers
{
    public class CartController : Controller
    {
        public static decimal chartTotal = 0;
        public static List<CartVM> chartList = new List<CartVM>();
        ProductAccess productAccess = new ProductAccess();
        // GET: Cart
        public ActionResult Index()
        {
            ViewBag.ChartList = chartList;
            chartTotal = 0;
            foreach (var item in chartList)
            {
                chartTotal += (decimal)item.TotalPrice;
            }
            ViewBag.ChartTotal = chartTotal;
            return View();
        }
        public ActionResult AddProductToChart(int? id)
        {
            if (id != null)
            {
                if (chartList.Any(m=>m.Product.ProductID==id))
                {
                    chartList.FirstOrDefault(m => m.Product.ProductID == id).ProductCount++;
                }
                else
                {
                    chartList.Add(new CartVM()
                    {
                        Product = productAccess.GetProductByID((int)id),
                        ProductCount = 1,
                    });
                }
            }
            foreach (var item in chartList)
            {
                item.TotalPrice = item.ProductCount * (decimal)item.Product.ProductPrice;
            }
            ViewBag.ChatList = chartList;
            return RedirectToAction("Index","Product");
        }
        public ActionResult RemoveProductFromChart(int? id)
        {
            if (id != null)
            {
                var total = chartList.FirstOrDefault(m => m.Product.ProductID == id).ProductCount;
                if (total>1)
                {
                    chartList.FirstOrDefault(m => m.Product.ProductID == id).ProductCount--;
                }
                else
                {
                    chartList.RemoveAll(m => m.Product.ProductID == id);
                }
            }
            foreach (var item in chartList)
            {
                item.TotalPrice = (decimal)(item.ProductCount * item.Product.ProductPrice);
            }

            ViewBag.ChartList = chartList;

            return RedirectToAction("Index");
        }
    }
}