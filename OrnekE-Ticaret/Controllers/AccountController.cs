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
    public class AccountController : Controller
    {
        UserAccess userAccess = new UserAccess();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserVM user )
        {
            if (userAccess.IsUserLogin(user.Email, user.Password))
            {
                var user1 = userAccess.GetUserByEmail(user.Email);
                Session.Add("NameLastName", user1.UserName + " " + user1.UserLastName);
                if (user1.UserRoleID==1)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Product");
                }   
            }
            else
            {
                ViewBag.LoginHata = "Hatalı Kullanıcı, Tekrar Deneyiniz.";
                return View();
            }


        }
       
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Girdiğiniz bilgileri kontrol ediniz.";
                return View();
            }
            var ısRegistered =userAccess.Register(user);
            if (ısRegistered)
            {
                ViewBag.Message = "Kayıt Başarılı!";
                return View("Login");
            }
            else
            {
                return View();
            }
           
        }
       


    }
}