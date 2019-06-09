using OrnekE_Ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrnekE_Ticaret.DAL
{
    public class UserAccess
    {
        ShoppingExampleDbEntities2 db;
        public bool IsUserLogin(string inputEmail, string inputPassword)
        {
            using (db=new ShoppingExampleDbEntities2())
            {
                if (db.User.Any(u => u.UserEmail == inputEmail))
                {
                    if (db.User.FirstOrDefault(u => u.UserEmail == inputEmail).UserPassword == inputPassword)
                        return true;
                }
                return false;
            }
        }
        public User GetUserByEmail(string inputEmail)
        {
            using (db=new ShoppingExampleDbEntities2())
            {
                var user = db.User.FirstOrDefault(m => m.UserEmail == inputEmail);
                return user;
            }
        }
        public bool Register(User user)
        {
            using (db=new ShoppingExampleDbEntities2())
            {
                db.User.Add(new User()
                {
                    UserName = user.UserName,
                    UserLastName = user.UserLastName,
                    UserEmail = user.UserEmail,
                    UserPassword = user.UserPassword


                });
                var save=db.SaveChanges();
                if (save>0)
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