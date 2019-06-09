using OrnekE_Ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrnekE_Ticaret.ViewModel
{
    public class CartVM
    {
        public Product Product { get; set; }
        public int ProductCount { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductPicture { get; set; }
    }
}